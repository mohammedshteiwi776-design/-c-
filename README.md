
​🛒 SuperMarket MS - نظام إدارة السوبر ماركت
​مشروع أكاديمي متكامل لإدارة المبيعات والمخازن ضمن قسم هندسة نظم الحاسوب - جامعة عمران.
​يهدف المشروع إلى بناء نظام إداري ذكي وشامل لإدارة عمليات البيع اليومية، تتبع حركة المخزون، وإدارة الحسابات والموردين، مع التركيز على دقة البيانات وسرعة التنفيذ وتوفير تقارير تحليلية تدعم اتخاذ القرار.
​👨‍💻 إعداد
​م.محمد شتيوي & م.محمد الخياطيم
​أستاذ المقرر:
د. عمر أبو سعلة
​🎯 أهداف المشروع
​أتمتة العمليات: تحويل إدارة المبيعات والمشتريات من النظام الورقي إلى النظام الرقمي بالكامل.
​إدارة المخزون: تتبع كميات المنتجات وتنبيه المستخدم عند اقتراب انتهاء الصلاحية أو نفاد الكمية.
​الدقة المالية: حساب الأرباح، المبيعات اليومية، وضبط الحسابات مع الموردين والعملاء.
​تعدد المستخدمين: توفير صلاحيات مختلفة (مدير، محاسب، كاشير) لضمان أمن البيانات.
​واجهة مستخدم احترافية: تصميم واجهات Windows Forms سهلة التعامل وسريعة الاستجابة.
​🏗️ هيكل الحل (Solution Layout)
​SuperMarketSystem.sln
│
├── 📁 SuperMarket.Core (Class Library - Logic Layer)
│   ├── Models/ (تمثيل جداول قاعدة البيانات)
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── Invoice.cs
│   │   └── User.cs
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   └── ISalesManager.cs
│   └── Services/ (العمليات المنطقية والحسابية)
│       ├── InventoryService.cs
│       └── TaxCalculator.cs
│
├── 📁 SuperMarket.Data (Data Access Layer)
│   ├── Context/ (اتصال قاعدة البيانات SQL Server)
│   │   └── DbConnector.cs
│   └── Repositories/ (عمليات CRUD)
│       ├── ProductRepository.cs
│       └── OrderRepository.cs
│
├── 📁 SuperMarket.WinFormsUI (Presentation Layer)
│   ├── Forms/
│   │   ├── MainForm.cs (الشاشة الرئيسية)
│   │   ├── PosForm.cs (شاشة نقطة البيع)
│   │   ├── InventoryForm.cs (إدارة المخازن)
│   │   └── ReportsForm.cs (التقارير)
│   ├── CustomControls/ (أدوات مخصصة لتصميم الواجهة)
│   └── Program.cs
│
├── 📁 SuperMarket.Reports (Reporting Module)
│   ├── SalesReport.rdlc
│   └── InvoiceTemplate.pdf
│
└── 📁 SuperMarket.Utils (Class Library)
├── Helpers/
│   ├── BackupHelper.cs (نسخ احتياطي)
│   ├── ValidationHelper.cs (التحقق من المدخلات)
│   └── Logger.cs (تسجيل الأخطاء)
└── BarcodeGenerator.cs (توليد وقراءة الأكواد)
​🛠️ التقنيات المستخدمة
​اللغة: C# (.NET Framework / .NET Core).
​قاعدة البيانات: SQL Server / Entity Framework.
​الواجهة: Windows Forms (WinForms) مع استخدام مكتبات Guna أو DevExpress لتحسين المظهر.
​التقارير: Microsoft Report Viewer (RDLC) أو Crystal Reports.