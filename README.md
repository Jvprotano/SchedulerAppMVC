# Company Scheduler App Readme

## Introduction

Welcome to the Company Scheduler App, a .NET 8 MVC web application designed for educational purposes. This app serves as a practical example for learning key concepts in web development using the .NET framework. Feel free to explore the codebase, experiment with modifications, and use it as a study resource.

## Features

- **User Authentication:** Secure user authentication system to ensure that only authorized personnel can access and manage schedules.

- **Dashboard:** A centralized dashboard displaying an overview of upcoming events, tasks, and appointments for quick reference.

- **Calendar View:** Intuitive calendar view for easy navigation and visualization of scheduled activities.

- **Task Management:** Efficient task creation, assignment, and tracking to ensure that teams stay organized and on top of their responsibilities.

- **Event Scheduling:** Schedule and manage events effortlessly, with options to set reminders and notifications.

- **Company-wide Communication:** Built-in messaging system to facilitate communication among team members regarding schedules and events.

- **Customization:** Flexible settings to tailor the app to the specific needs and preferences of each company.

## My Learning Goals

This study app is crafted to help me achieve my personal learning objectives:

- **Microservices Architecture:** I aim to delve into breaking down the application into smaller, independently deployable services, aligning with my keen interest in scalable architectures.

- **Containerization:** My goal is to master the art of containerization by learning how to containerize the application using Docker. I seek seamless deployment and scaling for efficient management.

- **API Development:** I aspire to dive deep into the development of RESTful APIs using ASP.NET Core. My focus is on mastering full-stack development, particularly integrating with Angular for robust frontend capabilities.

- **External System Integration:** I am eager to experiment with the integration of external communication systems such as email and WhatsApp. This will enhance communication channels and contribute to a more versatile application.

- **AI Integration:** My objective is to explore the integration of AI models within the application. I aim to understand and implement AI capabilities that generate recommended information, elevating the app's intelligence and user experience.

## Getting Started

1. **Prerequisites:**
   - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
   - [Visual Studio](https://visualstudio.microsoft.com/) or any preferred code editor
   - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) for database storage

2. **Clone the Repository:**
   ```bash
   git clone https://github.com/Jvprotano/SchedulingApp.git
   ```

3. **Database Setup:**
   - Update the connection string in `appsettings.json` with your SQL Server details.
   - Run migrations to create the database:
     ```bash
     dotnet ef database update
     ```

4. **Run the Application:**
   ```bash
   dotnet run
   ```
   Visit [http://localhost:5000](http://localhost:5000) in your browser.

## Configuration

- Modify the settings in the `appsettings.json` file to customize the app for your company's needs.

## Contributing

We welcome contributions! If you find any bugs or have ideas for new features, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE.md).

## Acknowledgments

- Thanks to the [.NET](https://dotnet.microsoft.com/) community for providing excellent documentation and support.

Happy scheduling!
The Company Scheduler App Team
