using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstTests;

public class LoginTests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    private void DangNhap(string taiKhoan = "standard_user", string matKhau = "secret_sauce")
    {
        driver.FindElement(By.Id("user-name")).SendKeys(taiKhoan);
        driver.FindElement(By.Id("password")).SendKeys(matKhau);
        driver.FindElement(By.Id("login-button")).Click();
    }

    [Test]
    public void DangNhap_DungTaiKhoan_ThanhCong()
    {
        DangNhap(); // tái dùng bước đăng nhập
        Assert.That(driver.Url,
            Does.Contain("inventory.html"));
    }

    [Test]
    public void ThuThapDanhSachSanPham()
    {
        DangNhap(); // tái dùng bước đăng nhập
        var items = driver.FindElements(By.ClassName("inventory_item"));
        foreach (var item in items) {
            var ten = item.FindElement(By.ClassName("inventory_item_name")).Text;
            var gia = item.FindElement(By.ClassName("inventory_item_price")).Text;
            Console.WriteLine($"{ten} - {gia}");
            Assert.That(items.Count, Is.EqualTo(6));
        }
    }
    [TearDown]
    public void TearDown() { driver.Quit(); driver.Dispose(); }
}
