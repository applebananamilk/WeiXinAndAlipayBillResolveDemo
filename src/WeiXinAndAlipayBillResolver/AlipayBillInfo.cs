namespace WeiXinAndAlipayBillResolver;

/// <summary>
/// 支付宝账单明细
/// </summary>
public class AlipayBillInfo
{
    /// <summary>
    /// 支付宝交易号
    /// </summary>
    public string AlipayTradeNo { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    public string MerchantOrderNo { get; set; }

    /// <summary>
    /// 业务类型
    /// </summary>
    public string BusinessType { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public string CreateTime { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public string CompletionTime { get; set; }

    /// <summary>
    /// 门店编号
    /// </summary>
    public string StoreNo { get; set; }

    /// <summary>
    /// 门店名称
    /// </summary>
    public string StoreName { get; set; }

    /// <summary>
    /// 操作员
    /// </summary>
    public string Operator { get; set; }

    /// <summary>
    /// 终端号
    /// </summary>
    public string TerminalNo { get; set; }

    /// <summary>
    /// 对方账户
    /// </summary>
    public string CounterpartyAccount { get; set; }

    /// <summary>
    /// 订单金额（元）
    /// </summary>
    public string OrderAmount { get; set; }

    /// <summary>
    /// 商家实收（元）
    /// </summary>
    public string ActualAmount { get; set; }

    /// <summary>
    /// 支付宝红包（元）
    /// </summary>
    public string AlipayRedPacket { get; set; }

    /// <summary>
    /// 集分宝（元）
    /// </summary>
    public string Jifenbao { get; set; }

    /// <summary>
    /// 支付宝优惠（元）
    /// </summary>
    public string AlipayDiscount { get; set; }

    /// <summary>
    /// 商家优惠（元）
    /// </summary>
    public string MerchantDiscount { get; set; }

    /// <summary>
    /// 券核销金额（元）
    /// </summary>
    public string CouponVerificationAmount { get; set; }

    /// <summary>
    /// 券名称
    /// </summary>
    public string CouponName { get; set; }

    /// <summary>
    /// 商家红包消费金额（元）
    /// </summary>
    public string MerchantRedPacketAmount { get; set; }

    /// <summary>
    /// 卡消费金额（元）
    /// </summary>
    public string CardAmount { get; set; }

    /// <summary>
    /// 退款批次号/请求号
    /// </summary>
    public string RefundBatchNo { get; set; }

    /// <summary>
    /// 服务费（元）
    /// </summary>
    public string ServiceFee { get; set; }

    /// <summary>
    /// 分润（元）
    /// </summary>
    public string ShareProfit { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Comment { get; set; }
}
