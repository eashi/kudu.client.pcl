﻿using System.IO;

namespace Kudu.Contracts.PCL.SourceControl.Git
{
    public interface IGitServer
    {
        void SetDeployer(string deployer);
        void AdvertiseUploadPack(Stream output);
        void AdvertiseReceivePack(Stream output);
        void Receive(Stream inputStream, Stream outputStream);
        void Upload(Stream inputStream, Stream outputStream);
    }
}
