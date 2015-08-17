﻿using System;
using System.Collections.Generic;

namespace FunctionalDemo
{
    public class ObjectOriented
    {
        public static void Main()
        {
            var reportingService = CompositionRoot.Compose();

            reportingService.RunCustomerReportBatch();
        }
    }

    public static class CompositionRoot
    {
        public static ReportingService Compose()
        {
            // Composition is usually far more complex
            return new ReportingService(
                new CustomerData(),
                new ReportBuilder(),
                new Emailer()
                );
        }
    }

    public class ReportingService
    {
        // Injecting dependencies as constructor argumnets - Pure DI
        public ReportingService(ICustomerData customerData, IReportBuilder reportBuilder, IEmailer emailer)
        {
            CustomerData = customerData;
            ReportBuilder = reportBuilder;
            Emailer = emailer;
        }

        // Store dependencies in Class Properties.. could be in Class Fields instead
        public ICustomerData CustomerData { get; private set; }
        public IReportBuilder ReportBuilder { get; private set; }
        public IEmailer Emailer { get; private set; }

        public void RunCustomerReportBatch()
        {
            var customers = CustomerData.GetCustomersForCustomerReport();

            foreach (var customer in customers)
            {
                var report = ReportBuilder.CreateCustomerReport(customer);
                Emailer.Send(report.ToAddress, report.Body);
            }
        }
    }

    public interface ICustomerData
    {
        IEnumerable<Customer> GetCustomersForCustomerReport();
    }

    public class CustomerData : ICustomerData
    {
        public IEnumerable<Customer> GetCustomersForCustomerReport()
        {
            // pretend to do data access
            yield return new Customer("mike@mikelair.com");
            yield return new Customer("leo@leofort.com");
            yield return new Customer("yuna@yunacastle.com");
        }
    }

    public interface IReportBuilder
    {
        Report CreateCustomerReport(Customer customer);
    }

    public class ReportBuilder : IReportBuilder
    {
        public Report CreateCustomerReport(Customer customer)
        {
            // C#6 string interpolation
            var body = $"This is the report for {customer.Email}!";
            return new Report(customer.Email, body);
        }
    }

    public interface IEmailer
    {
        void Send(string toAddress, string body);
    }

    public class Emailer : IEmailer
    {
        public void Send(string toAddress, string body)
        {
            // pretend to send an email here
            //Console.Out.WriteLine("Sent Email to: {0}, Body: '{1}'", toAddress, body);
            Console.WriteLine($"Sent Email to: {toAddress}, Body: '{body}'");
        }
    }
}