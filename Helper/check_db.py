import pyodbc # You might need to 'pip install pyodbc'

# This script just checks if we can connect to the database
conn_str = "Driver={ODBC Driver 18 for SQL Server};Server=YOUR_SERVER.database.windows.net;Database=YOUR_DB;Uid=YOUR_USER;Pwd=YOUR_PASSWORD;"

try:
    conn = pyodbc.connect(conn_str)
    print("✅ Connection Successful! The database is awake.")
except Exception as e:
    print(f"❌ Oops! Something is wrong: {e}")