using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto_form
{
    public class Mail_Smtp
    {
        public void Send(string Mail_to,string Msg) {

            SmtpClient client = new SmtpClient("smtp주소", 587);
            client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            client.EnableSsl = true;  // SSL을 사용한다.
            client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
            client.Credentials = new System.Net.NetworkCredential("아이디", "암호");

            MailAddress from = new MailAddress("poixgks@naver.com", "한수희", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(Mail_to, "이름은 사치", System.Text.Encoding.UTF8);

            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;
            message.Body = Msg;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "생성된 번호 입니다.";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            try
            {
                // 동기로 메일을 보낸다.
                client.Send(message);

                // Clean up.
                message.Dispose();

                MessageBox.Show("Mail 전송 완료","메일");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
