# StackOverflow Tags API Project

## Project Overview
This project is a REST API developed with .NET 8 and C#, designed to interact with the StackOverflow API to fetch, cache, and provide insights into programming tags. It dynamically retrieves over 1000 tags, calculates their percentage representation within the dataset, and exposes this data through a paginated and sortable API.

## Features
- **Data Fetching**: Automatically or on-demand retrieval of tags from the StackOverflow API, supporting both full and incremental fetches.
- **Data Analysis**: Calculation of each tag's percentage share within the total dataset.
- **API Exposure**: Paginated and sortable API endpoints for accessing tag data, with sorting by name and percentage in both directions.
- **Manual Refresh**: An API method to force the data to refresh from StackOverflow.
- **OpenAPI Documentation**: Complete OpenAPI specifications for all API methods.
- **Logging & Error Handling**: Comprehensive logging and error handling, along with runtime configuration management.
- **Testing**: Selected unit and integration tests to ensure functionality and reliability.
- **Containerization**: Docker integration for consistent deployment and runtime environments.


## How to Run
To run this project, ensure Docker is installed and operational on your system, then execute:
```bash
docker compose up
