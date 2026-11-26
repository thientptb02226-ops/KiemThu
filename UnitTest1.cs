using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstTests;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver(); // mở trình duyệt trước mỗi test
    }

    [Test]
    public void MoTrangChu_ThanhCong()
    {
        driver.Navigate().GoToUrl("https://fpt.edu.vn");
        Assert.That(driver.Title, Is.Not.Empty);
        Thread.Sleep(3000); // giữ trình duyệt 3 giây để xem kết quả
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();     // đóng trình duyệt sau mỗi test
        driver.Dispose();  // giải phóng tài nguyên
    }
}