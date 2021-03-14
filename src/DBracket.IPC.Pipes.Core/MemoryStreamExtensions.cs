/// <summary>
/// Byte array as "StringBuilder" works, ref https://stackoverflow.com/questions/4015602/equivalent-of-stringbuilder-for-byte-arrays
/// I love stackoverflow, the best solutions are usually not your own ;)
/// </summary>

using System.IO;

namespace DBracket.IPC.Pipes.Core
{
    internal static class MemoryStreamExtensions
    {
        #region Private Fields

        #endregion



        #region Constructor

        #endregion



        #region Methods
        #region Public Methods
        public static void Append(this MemoryStream stream, byte value)
        {
            stream.Append(new[] { value });
        }

        public static void Append(this MemoryStream stream, byte[] values)
        {
            stream.Write(values, 0, values.Length);
        }

        public static void Append(this MemoryStream stream, byte[] values, int length)
        {
            stream.Write(values, 0, length);
        }
        #endregion

        #region Private Methods

        #endregion

        #region Events

        #endregion
        #endregion



        #region Public Properties
        #region Properties

        #endregion

        #region Events

        #endregion
        #endregion
    }
}