# SecurePass & Malware Scanner

A lightweight, terminal-based **Password Manager** and **Malware File Scanner** utility built with C# and running on the .NET Script environment. 

This project demonstrates clean architecture by separating password management logic from the security components, utilizing multi-file linking via C# scripting (`#load`).

## 🚀 Features

### 1. Password Manager (`PassManager.cs`)
* **Secure Generation:** Generates strong, randomized passwords using a broad character set (letters, numbers, and special symbols).
* **CRUD Operations:** Create, view, update, and delete website or account credentials easily.
* **Flat-File Storage:** Saves all records to a local `passwords.txt` file safely.

### 2. AntiMalware Scanner (`AntiMalware.cs`)
* **SHA-256 Hashing:** Automatically computes unique cryptographic hashes for files.
* **Database Matching:** Compares file hashes against a local signature database (`hashes.txt`).
* **Directory Scanning:** Capable of recursively scanning entire folders to find deep-nested malicious threats.

---

## 🛠️ Prerequisites

Before running the application, make sure you have the following installed on your machine:

1. **.NET SDK** (v6.0 or newer recommended)
2. **dotnet-script tool**
   Install it globally via your terminal using:
   ```bash
   dotnet tool install -g dotnet-script
   ```

---

## 📂 File Structure

Ensure both script files and your signature database are located within the **same directory**:

```text
├── PassManager.cs       # Main application & Password management UI
├── AntiMalware.cs      # Core engine for cryptographic file scanning
└── hashes.txt          # Malware signature database (one SHA-256 hash per line)
```

---

## 🚀 How to Run

1. Open your terminal (PowerShell, Command Prompt, or Bash).
2. Navigate to the directory containing the project files.
3. Run the main script file:
   ```bash
   dotnet script ".\PassManager.cs"
   ```

---

## 📖 How to Use

### Password Manager
* Upon launching, select options `1` through `4` to list, create, erase, or change password entries.
* Entries are written into `passwords.txt` in a human-readable `Description: Password` structure.

### Malware Scanner
* Press `5` from the main menu to initiate the **AntiVirus** application.
* Provide a direct file path (e.g., `C:\Users\user\Downloads\file.exe`) or an entire folder path to execute a batch scan.
* The system checks the computed hashes against `hashes.txt` and highlights statuses using **Green (Clean)** or **Red (Malicious)** markers.

---

## 🔒 Security Note
This project is developed for educational and personal workflow efficiency purposes. When handling production-level workflows, always remember to add encryption layers over flat-text credential storages.
