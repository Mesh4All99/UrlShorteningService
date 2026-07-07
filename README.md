<div dir="rtl" align="right">

# خدمة اختصار الروابط (ShorterUrls)

واجهة برمجية (API) لاختصار الروابط مبنية بـ ASP.NET Core Minimal APIs مع قاعدة بيانات PostgreSQL.

## المتطلبات

- .NET 10 SDK
- PostgreSQL

## الإعداد

**١. استنساخ المشروع:**

```bash
git clone https://github.com/Mesh4All99/UrlShorteningService.git
cd UrlShorteningService
```

**٢. إعداد قاعدة البيانات:**

عدّل سلسلة الاتصال في `appsettings.json`:

```json
"ConnectionStrings": {
  "Default": "Host=localhost; Port=5432; Database=UrlShorterDb; Username=postgres; Password=postgres;"
}
```

**٣. تطبيق الـ Migrations:**

```bash
dotnet ef database update
```

**٤. تشغيل المشروع:**

```bash
dotnet run
```

توثيق الـ API متاح عبر Scalar على المسار `/docs` في وضع التطوير.

## نقاط النهاية (Endpoints)

### اختصار رابط

```
POST /shorturl
```

**جسم الطلب:**

```json
{
  "url": "https://example.com/long-url",
  "alias": "myalias"       // اختياري
}
```

- في حال تمرير `alias`: يُستخدم كمعرّف مخصص للرابط المختصر.
- في حال عدم تمريره: يُولَّد معرّف عشوائي من ٧ خانات.

**الاستجابة:**

```json
{
  "shortenUrl": "https://localhost:7xxx/myalias"
}
```

### إعادة التوجيه

```
GET /{alias}
```

يُعيد التوجيه إلى الرابط الأصلي ويزيد عدّاد النقرات.

## هيكل المشروع

```
ShorterUrls/
├── Data/                  # سياق قاعدة البيانات (DbContext)
├── Dtos/                  # كائنات نقل البيانات (Request/Response)
├── Helpers/               # مولّد المعرّفات العشوائية
├── Migrations/            # ملفات ترحيل قاعدة البيانات
├── Models/                # نموذج الرابط (Url)
├── Program.cs             # نقطة الدخول وتعريف الـ Endpoints
├── appsettings.json       # إعدادات التطبيق
└── ShorterUrls.csproj     # ملف المشروع
```

## التقنيات المستخدمة

- **ASP.NET Core 10** — Minimal APIs
- **Entity Framework Core 10** — ORM
- **Npgsql** — مزوّد PostgreSQL
- **Scalar** — توثيق الـ API

## الرخصة

هذا المشروع متاح للاستخدام الحر.

</div>
