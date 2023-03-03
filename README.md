# 🔒 Password Manager API 🔒
> Status: Finished 👌

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
        <li><a href="#features">Features</a></li>
        <li><a href="#what-i-learned">What I Learned</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#requirements">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>

# About the Project
It's a REST API made with C# planned for me, where I perform a password manager api 
to manage your credentials from various websites and apps to stay save and secure.

## Built with
- [x] C# .NET
- [x] Entity Framework
- [x] SQLite

## Features
- [x] Json Web Token Authentication (JWT)
- [x] Add and keep safe yours credentials
- [x] Show your added credentials quickly

## What I Learned
- [x] Fluent API and Fluent Mapping with EF
- [x] MVC Pattern
- [x] Token Services (JWT) 
- [x] HTTP Protocol in the .NET
- [x] EF Migrations

# Getting Started
This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

## requirements
- [ ] .NET 6

### Installation
1. Clone the repo
   ```
   git clone https://github.com/rlksx/password-manager.git
   ```
2. Install packages
   ```
   dotnet build
   ```
## Usage
### Register your account 
```
https://localhost:7215/api/accounts/register
```
![image](https://user-images.githubusercontent.com/99461398/207970965-690f80d1-55e0-4b38-a658-5caf5fb8cede.png)

### Login in your accoount and get your token
```
https://localhost:7215/api/accounts/login
```
![image](https://user-images.githubusercontent.com/99461398/207971347-9c378c61-6319-4013-814c-2d9c9f81cd0d.png)

### Add a new credential
```
https://localhost:7215/api/credentials/new-credential
```
![image](https://user-images.githubusercontent.com/99461398/207971617-d1059d30-c84f-445c-a11a-bf1701694ef7.png)

### `Get` your credentials
```
https://localhost:7215/api/credentials/
```
![image](https://user-images.githubusercontent.com/99461398/207971873-49b64769-b1b7-4654-a270-0b4a619c656d.png)

### `Delete` a credential
```
https://localhost:7215/api/credentials/delete/{id}
```
![image](https://user-images.githubusercontent.com/99461398/208300768-5e603d06-8601-48b2-80f9-539396b190a5.png)

# License
Distributed under the MIT License. See `LICENSE.txt` for more information.
