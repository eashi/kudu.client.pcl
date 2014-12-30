﻿using System.Collections.Generic;
using System.IO;

namespace Kudu.Contracts.PCL.Jobs
{
    public interface IJobsManager<TJob> where TJob : JobBase, new()
    {
        IEnumerable<TJob> ListJobs();

        TJob GetJob(string jobName);

        TJob CreateOrReplaceJobFromZipStream(Stream zipStream, string jobName);

        TJob CreateOrReplaceJobFromFileStream(Stream scriptFileStream, string jobName, string scriptFileName);

        void DeleteJob(string jobName);

        JobSettings GetJobSettings(string jobName);

        void SetJobSettings(string jobName, JobSettings jobSettings);

        void CleanupDeletedJobs();

        void SyncExternalJobs(string sourcePath, string sourceName);

        void CleanupExternalJobs(string sourceName);
    }
}