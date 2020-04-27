using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using AnthonyscheeresApi.Models;

namespace AnthonyscheeresApi.Utilities
{

    /**
* @author Anthony Scheeres
*/
     internal class MailUtilities

    {
        private MailAddress fromAddress = new MailAddress(DataModel.getConfigModel().mailCredentials.username, "Chantemerle");
        private string fromPassword = DataModel.getConfigModel().mailCredentials.password;
        private string mailClient = DataModel.getConfigModel().mailCredentials.mailService;

        /**
* @author Anthony Scheeres
*/
         internal MailUtilities()
        {

        }

         internal MailUtilities(MailAddress fromAddress, string fromPassword, string mailClient)
        {
            this.fromAddress = fromAddress;
            this.fromPassword = fromPassword;
            this.mailClient = mailClient;
        }


        /**
* @author Anthony Scheeres
*/
         internal void sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(string toEmailAddress, string username, string subject, string body)
        {
            sendEmailWithGmailToAdressWithABodyAndSubject(toEmailAddress, username, subject, body);
        }


        /**
* @author Anthony Scheeres
*/
         internal void sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(string toEmailAddress, string subject, string body)
        {
            string user = "Gebruiker";
            sendEmailWithGmailToAdressWithABodyAndSubject(toEmailAddress, user, subject, body);
        }


        /**
* @author Anthony Scheeres
*/
        private void sendEmailWithGmailToAdressWithABodyAndSubject(string toEmailAddress, string username, string subject, string body)
        {

            var toAddress = new MailAddress(toEmailAddress, username);


            var smtp = new SmtpClient
            {
                Host = this.mailClient,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
                smtp.Dispose();
            }
        }
    }
}