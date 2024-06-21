namespace WeiXinAndAlipayBillResolver;

/// <summary>
/// 微信对账单结果类
/// </summary>
public class WeChatPayBillResult
{
    /// <summary>
    /// 对账明细列表
    /// </summary>
    public List<WeChatPayBillInfo> BillInfos { get; set; } = new();

    /// <summary>
    /// 总交易单数
    /// </summary>
    public string TotalRecord { get; set; }

    /// <summary>
    /// 应结订单总金额
    /// </summary>
    public string TotalFee { get; set; }

    /// <summary>
    /// 退款总金额
    /// </summary>
    public string TotalRefundFee { get; set; }

    /// <summary>
    /// 充值券退款总金额
    /// </summary>
    public string TotalCouponFee { get; set; }

    /// <summary>
    /// 手续费总金额
    /// </summary>
    public string TotalPoundageFee { get; set; }

    /// <summary>
    /// 订单总金额
    /// </summary>
    public string TotalAmount { get; set; }

    /// <summary>
    /// 申请退款总金额
    /// </summary>
    public string TotalAppliedRefundFee { get; set; }

    /// <summary>
    /// 从原始对账单字符串里构造出WeChatPayBillResult对象，用于构建当日所有订单信息
    /// </summary>
    public static WeChatPayBillResult FromRawBillResultString(string responseContent)
    {
        const string totalDealCount = "总交易单数";
        string listStr = string.Empty;
        string objStr = string.Empty;
        if (responseContent.Contains(totalDealCount))
        {
            listStr = responseContent.Substring(0, responseContent.IndexOf(totalDealCount));
            objStr = responseContent.Substring(responseContent.IndexOf(totalDealCount));
        }

        List<WeChatPayBillInfo> results = new();
        // 去空格
        string newStr = listStr.Replace(",", " ");
        // 数据分组
        string[] tempStr = newStr.Split("`");
        // 分组标题
        string[] t = tempStr[0].Split(" ");
        // 计算循环次数
        int j = tempStr.Length / t.Length;
        // 纪录数组下标
        int k = 1;
        // 交易时间,公众账号ID,商户号,特约商户号,设备号,微信订单号,商户订单号,用户标识,交易类型,交易状态,付款银行,货币种类,
        // 应结订单金额,代金券金额,微信退款单号,商户退款单号,退款金额,充值券退款金额,退款类型,退款状态,商品名称,商户数据包,手续费,费率,
        // 订单金额,申请退款金额,费率备注  （开通免充值券后的结算对账单专有的三个字段）
        for (int i = 0; i < j; i++)
        {
            WeChatPayBillInfo result = new();
            result.TradeTime = tempStr[k].Trim();
            result.AppId = tempStr[k + 1].Trim();
            result.MchId = tempStr[k + 2].Trim();
            result.SubMchId = tempStr[k + 3].Trim();
            result.DeviceInfo = tempStr[k + 4].Trim();
            result.TransactionId = tempStr[k + 5].Trim();
            result.OutTradeNo = tempStr[k + 6].Trim();
            result.OpenId = tempStr[k + 7].Trim();
            result.TradeType = tempStr[k + 8].Trim();
            result.TradeState = tempStr[k + 9].Trim();
            result.BankType = tempStr[k + 10].Trim();
            result.FeeType = tempStr[k + 11].Trim();
            result.TotalFee = tempStr[k + 12].Trim();
            result.CouponFee = tempStr[k + 13].Trim();
            result.RefundId = tempStr[k + 14].Trim();
            result.OutRefundNo = tempStr[k + 15].Trim();
            result.SettlementRefundFee = tempStr[k + 16].Trim();
            result.CouponRefundFee = tempStr[k + 17].Trim();
            result.RefundChannel = tempStr[k + 18].Trim();
            result.RefundState = tempStr[k + 19].Trim();
            result.Body = tempStr[k + 20].Trim();
            result.Attach = tempStr[k + 21].Trim();
            result.Poundage = tempStr[k + 22].Trim();
            result.PoundageRate = tempStr[k + 23].Trim();
            if (t.Length > 24)
            {
                // 开通免充值券后的结算对账单
                result.TotalAmount = tempStr[k + 24].Trim();
                result.AppliedRefundAmount = tempStr[k + 25].Trim();
                result.FeeRemark = tempStr[k + 26].Trim();
            }
            results.Add(result);
            k += t.Length;
        }

        WeChatPayBillResult billResult = new();
        billResult.BillInfos = results;

        /*
		 * 总交易单数,应结订单总金额,退款总金额,充值券退款总金额,手续费总金额,订单总金额,申请退款总金额 `48,`5.76,`1.42,`0.00,`0.01000,`5.76,`1.42
		 * 参考以上格式进行取值
		 */
        string[] totalTempStr = objStr.Replace(",", " ").Split("`");
        billResult.TotalRecord = totalTempStr[1].Trim();
        billResult.TotalFee = totalTempStr[2].Trim();
        billResult.TotalRefundFee = totalTempStr[3].Trim();
        billResult.TotalCouponFee = totalTempStr[4].Trim();
        billResult.TotalPoundageFee = totalTempStr[5].Trim();
        billResult.TotalAmount = Get(totalTempStr, 6);
        billResult.TotalAppliedRefundFee = Get(totalTempStr, 7);

        return billResult;
    }

    private static string Get(string[] array, int idx)
    {
        return Get(array, idx, array.Length);
    }

    private static string Get(string[] array, int idx, int length)
    {
        if (length > idx)
        {
            return array[idx].Trim();
        }
        return null;
    }
}