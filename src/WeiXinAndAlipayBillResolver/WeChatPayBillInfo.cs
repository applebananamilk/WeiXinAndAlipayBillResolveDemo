namespace WeiXinAndAlipayBillResolver;

/// <summary>
/// 微信账单明细
/// </summary>
/// <remark>
/// 交易时间:2017-04-06 01:00:02 公众账号ID: 商户号: 子商户号:0 设备号:WEB 微信订单号: 商户订单号:2017040519091071873216 用户标识: 交易类型:NATIVE
/// 交易状态:REFUND 付款银行:CFT 货币种类:CNY 总金额:0.00 企业红包金额: 0.00 微信退款单号: 商户退款单号: 20170406010000933 退款金额: 0.01 企业红包退款金额: 0.00
/// 退款类型:ORIGINAL 退款状态:SUCCESS 商品名称: 商户数据包: 手续费: 0.00000 费率: 0.60 %
/// </remark>
public class WeChatPayBillInfo
{
    /// <summary>
    /// 交易时间
    /// </summary>
    public string TradeTime { get; set; }

    /// <summary>
    /// 公众账号ID
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 商户号
    /// </summary>
    public string MchId { get; set; }

    /// <summary>
    /// 特约商户号
    /// </summary>
    public string SubMchId { get; set; }

    /// <summary>
    /// 设备号
    /// </summary>
    public string DeviceInfo { get; set; }

    /// <summary>
    /// 微信订单号
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 用户标识
    /// </summary>
    public string OpenId { get; set; }

    /// <summary>
    /// 交易类型
    /// </summary>
    public string TradeType { get; set; }

    /// <summary>
    /// 交易状态
    /// </summary>
    public string TradeState { get; set; }

    /// <summary>
    /// 付款银行
    /// </summary>
    public string BankType { get; set; }

    /// <summary>
    /// 货币种类
    /// </summary>
    public string FeeType { get; set; }

    /// <summary>
    /// 总金额
    /// </summary>
    public string TotalFee { get; set; }

    /// <summary>
    /// 企业红包金额
    /// </summary>
    public string CouponFee { get; set; }

    /// <summary>
    /// 微信退款单号
    /// </summary>
    public string RefundId { get; set; }

    /// <summary>
    /// 商户退款单号
    /// </summary>
    public string OutRefundNo { get; set; }

    /// <summary>
    /// 退款金额
    /// </summary>
    public string SettlementRefundFee { get; set; }

    /// <summary>
    /// 企业红包退款金额
    /// </summary>
    public string CouponRefundFee { get; set; }

    /// <summary>
    /// 退款类型
    /// </summary>
    public string RefundChannel { get; set; }

    /// <summary>
    /// 退款状态
    /// </summary>
    public string RefundState { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// 商户数据包
    /// </summary>
    public string Attach { get; set; }

    /// <summary>
    /// 手续费
    /// </summary>
    public string Poundage { get; set; }

    /// <summary>
    /// 费率
    /// </summary>
    public string PoundageRate { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    public string TotalAmount { get; set; }

    /// <summary>
    /// 申请退款金额
    /// </summary>
    public string AppliedRefundAmount { get; set; }

    /// <summary>
    /// 费率备注
    /// </summary>
    public string FeeRemark { get; set; }

    /// <summary>
    /// 退款申请时间
    /// </summary>
    public string RefundTime { get; set; }

    /// <summary>
    /// 退款成功时间
    /// </summary>
    public string RefundSuccessTime { get; set; }
}
