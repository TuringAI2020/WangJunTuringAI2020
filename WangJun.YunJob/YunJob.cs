using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class YunJob:IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var task = new Task(() =>
            {
                var jobName = context.JobDetail.JobDataMap["name"];
                var param = context.JobDetail.JobDataMap["param"];
                Console.WriteLine($"执行作业\t{DateTime.Now}\t{jobName}\t{param}");
            });
            task.Start();
            return task;
        }

        public RES StartJob(string jobName, string param) {
            try
            {
                var factory = new StdSchedulerFactory();
                var scheduler = factory.GetScheduler();
                IJobDetail job = JobBuilder.Create<YunJob>().WithIdentity("job1", "group1").Build();
                job.JobDataMap.Put("param", param);
                job.JobDataMap.Put("name", jobName);
                ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithCronSchedule("0/5 * * * * ?")     //5秒执行一次 
                .Build();
                scheduler.Result.ScheduleJob(job, trigger);
                scheduler.Result.Start();
                return RES.OK();
            }
            catch (Exception ex)
            {

                return RES.FAIL();
            }

        }
    }
}
