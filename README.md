# Monica Salon — Aplikasi Mobile UI (Phase 1)

Aplikasi **UI-only** untuk Monica Salon, dibangun dengan **.NET MAUI 10** dan **UraniumUI 3.0** sebagai framework presentasi UI. Proyek ini adalah tugas UAS mata kuliah Pemrograman Visual.

> **Scope Phase 1:** hanya 3 halaman Customer UI. **Tidak ada** koneksi database, backend, halaman admin, atau alur checkout. Semua data masih *mock data* (hardcoded di ViewModel).

---

## 📱 Halaman yang Tersedia

| Halaman | File | Isi |
|---------|------|-----|
| Login | `Views/LoginPage.xaml` | Onboarding + form login (email & password) dengan validasi |
| Register | `Views/RegisterPage.xaml` | Form pendaftaran customer (nama, email, telepon, password, konfirmasi, checkbox S&K) |
| Home Customer | `Views/HomeCustomerPage.xaml` | Dashboard customer: header, search, banner promo, kategori layanan, daftar layanan, bottom navigation, bottom sheet detail layanan |

Alur navigasi: `LoginPage` → (Login / Daftar) → `RegisterPage` / `HomeCustomerPage`.

---

## ✅ Prasyarat (Requirements)

Pastikan sudah terinstal di komputer:

1. **Visual Studio 2022/2026** dengan workload **.NET Multi-platform App UI development (.NET MAUI)**
   — atau **VS Code** + ekstensi **.NET MAUI**.
2. **.NET SDK 10.0** (proyek ini memakai `net10.0-android`, `net10.0-ios`, `net10.0-maccatalyst`, dan `net10.0-windows10.0.19041.0`).
3. **Workload MAUI** terpasang. Cek dengan:
   ```bash
   dotnet workload list
   ```
   Kalau belum ada `maui` / `maui-windows`, install:
   ```bash
   dotnet workload install maui
   ```

> Cek versi SDK: `dotnet --version` harus **10.x**.

---

## 🚀 Cara Menjalankan (Clone → Run)

### 1. Clone repository

```bash
git clone https://github.com/chriswnt/UI_MONICASALON.git
cd UI_MONICASALON
```

### 2. Restore dependency (NuGet)

```bash
dotnet restore
```

### 3. Jalankan aplikasi

**Windows** (paling cepat untuk demo):
```bash
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

**Android** (butuh emulator atau HP dengan USB debugging aktif):
```bash
dotnet build -t:Run -f net10.0-android
```

**Lewat Visual Studio:**
1. Buka `UAS_APP_MONICASALON.slnx`.
2. Di toolbar atas, pilih target **Windows Machine** (atau emulator Android).
3. Tekan **F5**.

> ⚠️ Proyek iOS/MacCatalyst **tidak bisa** di-build di Windows tanpa Mac — ini normal, abaikan saja target tersebut.

---

## 🧱 Struktur Proyek

```
UAS_APP_MONICASALON/
├── App.xaml                    # Registrasi resource + tema UraniumUI
├── App.xaml.cs
├── AppShell.xaml               # Shell navigation (entry point: LoginPage)
├── MauiProgram.cs              # Registrasi UraniumUI, Material theme, font
├── AssemblyInfo.cs             # XmlnsDefinition untuk shim ButtonView
├── prd_monica_salon_phase_1.md # Dokumen spesifikasi (PRD) Phase 1
│
├── Controls/
│   └── ButtonView.cs           # Shim: <uranium:ButtonView> → UraniumUI Material
│
├── Models/                     # Model data (dummy)
│   ├── BannerItem.cs
│   ├── CategoryItem.cs
│   └── ServiceItem.cs
│
├── ViewModels/                 # MVVM (CommunityToolkit.Mvvm)
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   └── HomeCustomerViewModel.cs
│
├── Views/
│   ├── LoginPage.xaml(.cs)
│   ├── RegisterPage.xaml(.cs)
│   └── HomeCustomerPage.xaml(.cs)
│
├── Icons/
│   └── MaterialRegular.cs      # Kumpulan nama ikon Material Symbols
│
├── Platforms/                  # Konfigurasi per-platform (Android/iOS/Windows/Mac)
└── Resources/                  # Font, gambar, icon, splash, style warna
```

---

## 🎨 Tentang UraniumUI

Seluruh layout dan komponen UI memakai **UraniumUI** (bukan kontrol MAUI polos), sesuai aturan PRD:

| Kebutuhan | Komponen yang Dipakai |
|-----------|----------------------|
| Root halaman | `<uranium:UraniumContentPage>` |
| Input teks / email / telepon | `<material:TextField>` + `material:TextField.Icon` |
| Toggle show/hide password | `material:TextFieldPasswordShowHideAttachment` |
| Checkbox | `<material:CheckBox>` |
| Tombol interaktif (back, notif, filter, kategori, kartu, bottom nav) | `<uranium:ButtonView>` |
| Bottom sheet detail layanan | `<material:BottomSheetView>` |
| CTA utama | `<Button StyleClass="FilledButton">` (style dari UraniumUI.Material) |
| Validasi form | `<input:FormView>` + `validation:RequiredValidation` / `RegexValidation` / `MinLengthValidation` / `DigitsOnlyValidation` |
| Tema global | `<material:StyleResource ColorsOverride="..." />` di `App.xaml` |

### Catatan: kenapa ada `Controls/ButtonView.cs`?

Di **UraniumUI 3.0**, kontrol `ButtonView` pindah dari namespace `UraniumUI` ke `UraniumUI.Material.Controls`. Sementara PRD menulis sintaks `<uranium:ButtonView>`.

Agar XAML tetap sesuai PRD **tanpa** mengubah satu baris pun, dibuat *shim*:

```csharp
public class ButtonView : UraniumUI.Material.Controls.ButtonView { }
```

Shim ini didaftarkan lewat `AssemblyInfo.cs` (`XmlnsDefinition`) dan handler-nya didaftarkan di `MauiProgram.cs`. Karena mewarisi (`inherit`) kontrol Uranium asli, seluruh perilaku dan tampilan tetap milik UraniumUI.

### Palet Warna

| Warna | Hex | Pemakaian |
|-------|-----|-----------|
| Coral (primer) | `#D9534F` | Tombol utama, ikon aktif, aksen |
| Background | `#FAF7F5` | Latar semua halaman |
| Teks utama | `#1E1E1E` | Judul, label |
| Border / divider | `#EFE6E4` | Garis kartu dan pemisah |

---

## 🛠️ Build & Troubleshooting

**Bersihkan hasil build (kalau ada error aneh):**
```bash
dotnet clean
rm -rf bin obj
dotnet restore
```

**Error `NU1101` / package tidak ketemu** → cek koneksi internet, lalu `dotnet restore` ulang.

**Error XAML `ButtonView tidak dikenal`** → pastikan `AssemblyInfo.cs` masih ada dan `MauiProgram.cs` masih memanggil `UseUraniumUI()` + `UseUraniumUIMaterial()`.

**Error Android SDK / emulator** → buka **Android Device Manager** di Visual Studio, buat/boot emulator dulu sebelum `dotnet build -t:Run -f net10.0-android`.

---

## 📦 Dependency

| Package | Versi | Fungsi |
|---------|-------|--------|
| `UraniumUI` | 3.0.0 | Core framework UI |
| `UraniumUI.Material` | 3.0.0 | Tema & komponen Material (TextField, ButtonView, BottomSheet, dll) |
| `UraniumUI.Icons.MaterialSymbols` | 3.0.0 | Ikon Material Symbols |
| `InputKit.Maui` | 4.6.0 | FormView & validasi form |
| `CommunityToolkit.Mvvm` | 8.4.2 | MVVM: `ObservableObject`, `RelayCommand` |

---

## 📄 Lisensi & Catatan Akademik

Proyek ini dibuat untuk keperluan **tugas UAS mata kuliah Pemrograman Visual**. Desain dan spesifikasi mengikuti dokumen `prd_monica_salon_phase_1.md` di dalam repository ini.

Referensi UraniumUI: <https://enisn-projects.io/docs/en/uranium/latest>