/* The MIT License (MIT)
* 
* Copyright (c) 2015 Marc Clifton
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/

// From: http://stackoverflow.com/questions/34478513/c-sharp-full-duplex-asynchronous-named-pipes-net
// See Eric Frazer's Q and self answer

// ClientPipe is based on the Full Duplex Pipeclass https://www.codeproject.com/Articles/1179195/Full-Duplex-Asynchronous-Read-Write-with-Named-Pip

using System;
using System.IO.Pipes;

namespace DBracket.IPC.Pipes.Core
{
    /// <summary>
    /// ClientPipe is based on the Full Duplex Pipeclass https://www.codeproject.com/Articles/1179195/Full-Duplex-Asynchronous-Read-Write-with-Named-Pip
    /// </summary>
    public class ClientPipe : BasicPipe
    {
        #region Private Fields
        protected NamedPipeClientStream clientPipeStream;
        #endregion



        #region Constructor
        public ClientPipe(string serverName, string pipeName, Action<BasicPipe> asyncReaderStart)
        {
            this.asyncReaderStart = asyncReaderStart;
            clientPipeStream = new NamedPipeClientStream(serverName, pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
            pipeStream = clientPipeStream;
        }
        #endregion



        #region Methods
        #region Public Methods
        public void Connect()
        {
            Connect(0);
        }

        public bool Connect(int Timeout)
        {
            try
            {
                if (Timeout == 0)
                    clientPipeStream.Connect();
                else
                    clientPipeStream.Connect(Timeout);
                asyncReaderStart(this);
            }
            catch
            {
                return false;
            }

            return true;
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
