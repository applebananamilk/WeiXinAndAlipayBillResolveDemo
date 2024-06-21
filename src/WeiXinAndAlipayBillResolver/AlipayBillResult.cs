using System.IO.Compression;
using System.Text;

namespace WeiXinAndAlipayBillResolver;

/// <summary>
/// 支付宝对账单结果类
/// </summary>
public class AlipayBillResult
{
    /// <summary>
    /// 对账明细列表
    /// </summary>
    public List<AlipayBillInfo> AlipayBillInfos { get; set; } = new();

    /// <summary>
    /// 从压缩包字节中里构造出AlipayBillResult对象
    /// </summary>
    public static AlipayBillResult FromRawBillZipBytes(byte[] zipBytes)
    {
        if (zipBytes == null)
        {
            throw new ArgumentNullException(nameof(zipBytes));
        }

        var encoding = Encoding.GetEncoding("GBK");

        using MemoryStream ms = new MemoryStream(zipBytes);
        using ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Read, true, encoding);

        AlipayBillResult result = new();

        foreach (var entry in archive.Entries)
        {
            if (entry.Name.Contains("汇总"))
            {
                continue;
            }

            using StreamReader streamReader = new StreamReader(entry.Open(), encoding);
            bool header = true;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (!line.StartsWith('#'))
                {
                    // 首行是表头
                    if (header)
                    {
                        header = false;
                        continue;
                    }
                    string[] fields = line.Split(',');
                    var billInfo = new AlipayBillInfo();
                    billInfo.AlipayTradeNo = fields[0]?.Trim();
                    billInfo.MerchantOrderNo = fields[1]?.Trim();
                    billInfo.BusinessType = fields[2]?.Trim();
                    billInfo.ProductName = fields[3]?.Trim();
                    billInfo.CreateTime = fields[4]?.Trim();
                    billInfo.CompletionTime = fields[5]?.Trim();
                    billInfo.StoreNo = fields[6]?.Trim();
                    billInfo.StoreName = fields[7]?.Trim();
                    billInfo.Operator = fields[8]?.Trim();
                    billInfo.TerminalNo = fields[9]?.Trim();
                    billInfo.CounterpartyAccount = fields[10]?.Trim();
                    billInfo.OrderAmount = fields[11]?.Trim();
                    billInfo.ActualAmount = fields[12]?.Trim();
                    billInfo.AlipayRedPacket = fields[13]?.Trim();
                    billInfo.Jifenbao = fields[14]?.Trim();
                    billInfo.AlipayDiscount = fields[15]?.Trim();
                    billInfo.MerchantDiscount = fields[16]?.Trim();
                    billInfo.CouponVerificationAmount = fields[17]?.Trim();
                    billInfo.CouponName = fields[18]?.Trim();
                    billInfo.MerchantRedPacketAmount = fields[19]?.Trim();
                    billInfo.CardAmount = fields[20]?.Trim();
                    billInfo.RefundBatchNo = fields[21]?.Trim();
                    billInfo.ServiceFee = fields[22]?.Trim();
                    billInfo.ShareProfit = fields[23]?.Trim();
                    billInfo.Comment = fields[24]?.Trim();
                    result.AlipayBillInfos.Add(billInfo);
                }
            }
        }

        return result;
    }
}
