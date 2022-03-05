using UnityEngine;
using Object = UnityEngine.Object;

namespace StowyTools.Logger
{
	/// <summary>
	/// Utility class for logging in Unity.
	/// </summary>
	public static class BetterLogger
	{
		/// <summary>
		/// Color of the name of the object.
		/// This is the HTML light blue.
		/// </summary>
		private static readonly Color ObjectNameColor = new Color(173, 216, 230);

		/// <summary>
		/// Signature of the unity log function.
		/// </summary>
		public delegate void LogFunction(string str, Object obj);

		/// <summary>
		/// Adds HTML color tag around the string. Used to make the string colored when logging.
		/// </summary>
		/// <param name="str">String to color.</param>
		/// <param name="color">Color to apply to the string.</param>
		/// <returns>The color coded string.</returns>
		public static string ColorString(string str, Color color) =>
			$"<color={ColorUtility.ToHtmlStringRGBA(color)}>{str}</color>";

		/// <summary>
		/// Logs the provided text to the provided function.
		/// </summary>
		/// <param name="logFunction">The function to log with.</param>
		/// <param name="prefix">Prefix to add in front of the message.</param>
		/// <param name="obj">Object that triggers the log.</param>
		/// <param name="msg">Message to log.</param>
		private static void DoLog(LogFunction logFunction, string prefix, Object obj, params object[] msg)
		{
#if UNITY_EDITOR
			string name = ColorString((obj ? obj.name : "NullObject"), ObjectNameColor);
			logFunction($"{prefix}[{name}]: {string.Join("; ", msg)}\n ", obj);
#endif
		}

		/// <summary>
		/// Logs a message to the Unity console. 
		/// </summary>
		/// <param name="obj">Object that triggers the log.</param>
		/// <param name="msg">Message to log.</param>
		public static void Log(this Object obj, params object[] msg)
		{
			DoLog(Debug.Log, string.Empty, obj, msg);
		}

		/// <summary>
		/// Logs an error to the Unity console.
		/// </summary>
		/// <param name="obj">Object that triggers the log.</param>
		/// <param name="msg">Message to log.</param>
		public static void LogError(this Object obj, params object[] msg)
		{
			DoLog(Debug.LogError, ColorString("<!>", Color.red), obj, msg);
		}

		/// <summary>
		/// Logs a warning to the Unity console.
		/// </summary>
		/// <param name="obj">Object that triggers the log.</param>
		/// <param name="msg">Message to log.</param>
		public static void LogWarning(this Object obj, params object[] msg)
		{
			DoLog(Debug.LogWarning, ColorString("⚠️", Color.yellow), obj, msg);
		}

		/// <summary>
		/// Logs a success to the Unity console.
		/// </summary>
		/// <param name="obj">Object that triggers the log.</param>
		/// <param name="msg">Message to log.</param>
		public static void LogSuccess(this Object obj, params object[] msg)
		{
			DoLog(Debug.Log, ColorString("☻", Color.green), obj, msg);
		}
	}
}
