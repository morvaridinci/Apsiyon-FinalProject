# Apsiyon-Final Project
This Project provides better solution for apartment resident and managers, developed based on Apsiyon Company’s solution. In this project, apartment manager can register to system and they have privileges about adding, deleting and updating user and they can easily manage payment of floors.  

## 1-	What can managers do:
 -	They can adding apartment residents.
 -	They assign general debt of apartment residents according to type of their bill aspect(electricity bill, water bill, gas bill, condo fee).
 -	They can see  message of apartment residents.
 -	They can add, delete and update block and apartment floor.

## 2-	What can apartment residents 
- They can see total amount of their debt to assing them. 
-	They can pay thier debt by their credit card.
-	They can send message to apartment manager.

## 3- Database Diagram
![image](https://user-images.githubusercontent.com/77583188/125195252-8b30d000-e25d-11eb-9b79-9476362714c2.png)


## 4- Kullanılan Teknolojiler 
<img src="https://img.shields.io/badge/-ASP.NET%20CORE%20MVC-purple"></img><br/>
<img src="https://img.shields.io/badge/-Entity%20Framework-red"></img><br/>
<img src="https://img.shields.io/badge/-AutoMapper-purple"></img><br/>
<img src="https://img.shields.io/badge/-Identity-orange"></img><br/>
<img src="https://img.shields.io/badge/-Sql%20Server-brightgreen"></img><br/>
<img src="https://img.shields.io/badge/-MongoDb-yellow"></img><br/>
<img src="https://img.shields.io/badge/-UnitOfWork-darkblue"></img><br/>
<img src="https://img.shields.io/badge/-Bootstrap-darkgreen"></img><br/>
<img src="https://img.shields.io/badge/-C%23-lemon"></img><br/>
<img src="https://img.shields.io/badge/-Lazy%20Loading-black"></img><br/>
<img src="https://img.shields.io/badge/-json-blue"></img><br/>

## 5- To Do List 
-	I am aware of some problems and bugs, I will fix them in the nearest time. 
-	User interface will be getting better.
-	Apartment resident can demand urgent meeting after that urgent meeting notification will send to other apartment residents and they will vote if the most vote is accept then system will set the urgent meeting first Sunday of the week. This feature will be releasing after the fixes and user interface development. 

## 6-  Installation 
-	First clone the repository.
-	Secondly find appsettings.json in the project and change connection string based on your locally configured database connection string.
-	In Package manager console you should created code fist database with command on the below:

   	```
    Add-Migration init
   	Update-Database
    ```
<b>NOTE:</b>  For the starting application with appropriate way, you should add debt types on the database.
