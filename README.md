# Hospital-App
A hospital app which provides basic functionality regarding patient registration by receptionists and managing appointments, writing prescriptions using doctors panel.
## Description
App functionality is created to provide receptionists and doctors UI which interacts with MySql database, to help manage patients, write prescriptions, inform patients about prescriptions.
## Realized tasks
* Ability for users to register, login, reset password using Identity.
* Receptionists can register patients to an appointment, change the time of the appointment or cancel it.
* Appointments are reserved if one receptionist already chose a time for an appointment.
* Doctor can see paginated list of patients.
* Doctor can see paginated list of created prescriptions.
* Doctors can interact with written prescriptions and cancel them until 1 hour after being created.
* Patients receive an email about assigned prescription.
* An API for pharmacies to check prescriptions using patient tab number.
