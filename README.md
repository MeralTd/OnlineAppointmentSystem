# OnlineAppointmentSystem


<b> Project Overview:</b> We are looking to develop a robust and user-friendly Online Appointment Management System to allow users (customers) to book appointments for various services, with different levels of access for users and administrators. This system will be built using ASP.NET Core MVC for the backend and MSSQL for the database. The project will consist of the following key features:

## 1) User Authentication and Role-based Access Control:

* Users will log in with a username and password.
* Access to the system will be role-based (User or Admin).
* Admins will have full control over the system, while users can only make and manage appointments.

## 2) User Panel (Customer Interface):

* Users will be able to make, update, and cancel appointments.
* Appointment details (such as service type and date) will be stored and displayed dynamically.
* The appointment list will automatically update without page reloads using AJAX.

## 3) Admin Panel:

* Admins can manage users (create, update, delete, and assign roles).
* Admins can view and update the status of all appointments (approved, canceled, completed).

## 4) Database Design and Entity Framework Core:

* Use of Entity Framework Core with the Code-First approach to create and manage the database schema.
* Appointments, users, and services will be stored in the database, and relationships will be established between tables.

## 5) Technologies and Tools:

<b>Frontend:</b> HTML, CSS, JavaScript, jQuery, Toastr/SweetAlert for notifications.

<b>Backend:</b> ASP.NET Core MVC, C#, Entity Framework Core.

<b>Database:</b> MSSQL for storing and managing data.

## 6) Authentication & Authorization: 
Using ASP.NET Core Identity to handle user authentication and role-based access.

![Login](https://github.com/user-attachments/assets/e74cd484-d481-4cf1-b24a-558fde865587)
![AppointmetList](https://github.com/user-attachments/assets/4a0eb812-6081-49e3-82b9-f74be9ae6946)
![addAppointment](https://github.com/user-attachments/assets/0d1cd9fc-a326-4925-bf4e-36054888064e)
![UserLİst](https://github.com/user-attachments/assets/74dc9ee3-b4a2-4381-8c8c-f7f07782b35c)
![AddUser](https://github.com/user-attachments/assets/216a7c06-c6b2-427e-a16d-fad57efd2a43)
