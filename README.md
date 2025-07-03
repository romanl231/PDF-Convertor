# PDF Converter

A simple yet powerful WPF application for converting images and DOCX documents into PDF files. Built with modern technologies and following the **Model-View-ViewModel (MVVM)** design pattern for clean, maintainable code.

---

## ✨ Features

- Convert images (JPG, PNG, BMP, GIF, TIFF) to PDF
- Convert DOCX documents to PDF
- Simple and intuitive WPF user interface
- Built with **PdfSharpCore** and **Syncfusion** for high-quality PDF output
- Fast and lightweight
- Installer created with Inno Setup

---

## 🛠 Technologies Used

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- WPF
- MVVM Pattern
- [PdfSharpCore](https://github.com/ststeiger/PdfSharpCore)
- [Syncfusion.DocIO.NET](https://www.syncfusion.com/document-processing/net/docio)

---

## 📦 Installation

1. Download the installer (`PDFConverterSetup.exe`) from the [Releases](../../releases) page.
2. Run the setup and follow the installation wizard.
3. **IMPORTANT:** After installation, you need to place your Syncfusion license key into a file called `license.txt` inside the application folder:
    ```
    C:\Program Files\PDF Converter\license.txt
    ```
    The content of `license.txt` should be your Syncfusion license key string.

---

## 💻 How to Use

1. Launch the PDF Converter application.
2. Choose whether to:
    - Convert images to PDF
    - Convert DOCX documents to PDF
3. Select the files you wish to convert.
4. Click **Convert** and choose your output folder.
5. Done!

---

## 🔧 Development

### Prerequisites

- .NET SDK 8.0 or higher
- Visual Studio 2022 or Rider (or any IDE that supports WPF and .NET 7)

### Clone the Repository

```bash
git clone https://github.com/your-username/pdf-converter.git
cd pdf-converter
```

### Build the Project

```bash
dotnet build
```

Or open the `.sln` file in Visual Studio and build the solution.

---

## 🎁 License

This project uses third-party libraries that may require licenses for commercial use:

- **Syncfusion**: requires a valid license key for production use. You can obtain a free community license or purchase a commercial license from [Syncfusion](https://www.syncfusion.com).

