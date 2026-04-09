# 🚀 Omni Communication System

A complete IVR (Interactive Voice Response) and Call Management System built using .NET 10 and Twilio.

This system enables businesses to automate incoming calls, route them to agents, record conversations, and manage everything through a centralized admin dashboard.

---

## 🎯 Features

### 📞 Call Handling
- Incoming call handling using Twilio
- Dynamic IVR menu (Press 1, Press 2, etc.)
- Intelligent call routing to agents

### 🎙 Call Recording
- Record agent-customer conversations
- Store recording URLs securely
- Play recordings directly from dashboard

### 📊 Admin Dashboard
- Manage Agents (Add/Delete)
- Configure IVR menus dynamically
- View Call Logs with status & duration
- Play call recordings
- DataTables integration for better UI experience

### 🧠 Smart Flow
- Supports call transfer & recording actions
- Tracks full call lifecycle (initiated → ringing → in-progress → completed)
- Handles ParentCallSid for accurate tracking of multi-leg calls

---

## 🛠 Tech Stack

- **Backend:** .NET 10 (ASP.NET Core Web API + MVC)
- **Frontend:** ASP.NET Core MVC (Razor Views) + Bootstrap
- **Database:** SQL Server
- **Voice API:** Twilio
- **Architecture:** Clean Architecture (Domain, Application, Infrastructure, API, Web)

---

## 🧱 Project Structure
OmniCommunicationSystem
│
├── Omni.API # Twilio webhooks & call handling logic
├── Omni.Web # Admin dashboard (MVC UI)
├── Omni.Application # Business logic (commands/queries)
├── Omni.Infrastructure # Database & services
├── Omni.Domain # Entities & models


---

## 📸 Screenshots

- Call Logs Page
- <img width="1912" height="1003" alt="Screenshot 2026-04-09 153238" src="https://github.com/user-attachments/assets/17f4ef9f-069b-4f06-843f-0200e2d7d83e" />
- IVR Configuration
- <img width="1919" height="698" alt="Screenshot 2026-04-09 153346" src="https://github.com/user-attachments/assets/575fe7af-1938-47ed-a9a4-3e1e3b8d2cf0" />
- Agent Management  
<img width="1916" height="780" alt="Screenshot 2026-04-09 153403" src="https://github.com/user-attachments/assets/55c9e5e9-1f4d-4330-a187-3d971097647a" />


## 💼 Use Cases

- Call Center Systems  
- Customer Support Automation  
- Lead Handling & Routing  
- Appointment Booking Systems  
- Business Call Automation  

---

## 🔐 Security

- Twilio credentials handled securely in backend
- Recording access protected via API proxy

---

## 🚀 Future Enhancements

- Authentication & Role Management  
- Multi-tenant (company-based system)  
- AI Voice Agent integration  
- WhatsApp automation  
- Analytics Dashboard  

---

## ⭐ Support

If you find this project useful, consider giving it a star ⭐

---

## 📬 Contact

Available for freelance work and custom implementations.
