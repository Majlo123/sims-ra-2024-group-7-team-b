# Accommodation and Tour Booking Platform (sims-ra-2024-group7-team-b)

This repository contains the source code for a comprehensive booking platform, developed as a project for the Software Specification and Modeling course. The application allows users to register as accommodation Owners, Guests, Tour Guides, and Tourists, providing a rich set of features for managing properties, tours, and user interactions.

## Architecture Overview

The system is designed using a microservices architecture to ensure scalability, flexibility, and a clear separation of concerns. An API Gateway serves as the single entry point for all client requests, routing them to the appropriate backend service. Each microservice is an independent component with its own database.

The main services include:
* **API Gateway:** Routes all incoming requests.
* **Users Service:** Manages user accounts, profiles, authentication, and roles.
* **Accommodation Service:** Handles the creation, management, and booking of accommodations (apartments, houses, etc.).
* **Tour Service:** Manages the creation, scheduling, and booking of guided tours.
* **Rating Service:** Manages ratings and reviews for both accommodations and tours.
* **Notification Service:** Handles sending email and in-app notifications.

## Key Features

### For Owners
* **Accommodation Management:** Register new accommodations with details like location, type, capacity, and photos.
* **Reservation Management:** View and manage reservation change requests from guests.
* **Guest Ratings:** Rate guests based on cleanliness and rule adherence after their stay.
* **Statistics Dashboard:** View detailed analytics for each property, including reservation numbers, cancellations, and occupancy rates.
* **Renovation Scheduling:** Schedule and manage renovation periods for properties.

### For Guests
* **Advanced Search:** Search and filter accommodations by name, location, type, number of guests, and booking duration.
* **Booking System:** Check for available dates and book accommodations. The system also suggests alternative dates if the requested period is unavailable.
* **"Anywhere/Anytime" Search:** A special feature to find available accommodations anywhere for a specified number of guests and days.
* **Rating System:** Rate accommodations and owners on criteria like cleanliness and owner conduct.
* **Reservation Management:** Request date changes for existing reservations and cancel bookings according to the owner's policy.
* **Forums:** Create and participate in location-based forums to share experiences.

### For Guides
* **Tour Creation:** Create and manage guided tours with details such as location, description, language, key points, and schedule.
* **Live Tour Tracking:** Manage active tours in real-time, marking key points as they are visited and tracking tourist attendance.
* **Tour Statistics:** Access analytics on tour popularity and attendance demographics.
* **Request Management:** View and accept custom tour requests made by tourists.

### For Tourists
* **Tour Discovery:** Browse and search for available tours by location, duration, and language.
* **Booking:** Reserve spots on a tour for a specified number of people.
* **Custom Tour Requests:** Create requests for both simple and complex (multi-part) tours.
* **Voucher System:** Earn and use vouchers for tours, acquired through guide cancellations or by attending multiple tours.
* **Rating System:** Rate tours and guides on criteria like knowledge and tour interestingness.
## Technology Stack

* **Languages:** Go, Java, Python (multiple languages for different microservices)
* **Frameworks:** Gin (Go), Spring Boot (Java), Flask/Django (Python)
* **Frontend:** Angular / React / Vue with TypeScript
* **Architecture:** Microservices, REST, gRPC
* **Containerization:** Docker, Docker Compose
* **Databases:** PostgreSQL, MongoDB
* **API Gateway:** Ocelot / NGINX / Spring Cloud Gateway

## Prerequisites

* Docker
* Docker Compose

## Running the Application

The entire system can be started with a single command.

1.  **Clone the repository:**
    ```bash
    git clone <repository-url>
    cd sims-ra-2024-group7-team-b
    ```

2.  **Build and run all services:**
    * From the root directory of the project, run:
        ```bash
        docker-compose up --build
        ```

The API Gateway will be available at a specified port (e.g., `http://localhost:8000`), and all client requests should be directed to it.

## Repository Structure

This is a monorepo containing all microservices and the frontend application:
