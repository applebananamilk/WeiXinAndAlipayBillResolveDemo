# 微信和支付宝账单解析

使用方式如下

```csharp
internal class Program
{
    static void Main(string[] args)
    {
        // 添加这个才能使用 GBK 字符编码（支付宝压缩包解析需要）
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        // 微信
        string originalString = null;
        WeChatPayBillResult.FromRawBillResultString(originalString);

        // 支付宝
        byte[] zipBytes = null;
        AlipayBillResult.FromRawBillZipBytes(zipBytes);
    }
}
```

