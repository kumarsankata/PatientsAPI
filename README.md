# PatientsAPI
Patients API

# Software used
1. Microsoft Visual Studio 2019
2. ASP.Net Core
3. Entity Framework Core
4. Entity Framework Core InMemory database

# Endpoints or Methods included
GET http://localhost:50522/api/v1/patients
POST http://localhost:50522/api/v1/patients
PUT http://localhost:50522/api/v1/patients/{Id}
GET http://localhost:50522/api/v1/patients/GetPatientsPage?currentPage=1&pageSize=3

# Improvements can be done
1. Use Automapper instead of mapping individual object property
2. Make Pagination helper more generic
3. Return Pagination results in response header instead of response JSON body
4. 
