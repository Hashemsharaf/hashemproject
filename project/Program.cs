using System;

class AttendanceRecord
{
    public string EmployeeName { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan ArrivalTime { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public AttendanceRecord Previous { get; set; }
    public AttendanceRecord Next { get; set; }
}

class AttendanceSystem
{
    private AttendanceRecord head;

    public void RecordAttendance(string employeeName, DateTime date, TimeSpan arrivalTime, TimeSpan departureTime)
    {
        var newRecord = new AttendanceRecord
        {
            EmployeeName = employeeName,
            Date = date.Date,
            ArrivalTime = arrivalTime,
            DepartureTime = departureTime
        };

        if (head == null)
        {
            head = newRecord;
        }
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            newRecord.Previous = current;
            current.Next = newRecord;
        }
    }

    public void DisplayAttendanceForEmployee(string employeeName)
    {
        var current = head;
        while (current != null)
        {
            if (current.EmployeeName.Equals(employeeName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Employee: {current.EmployeeName}, Date: {current.Date.ToShortDateString()}, Arrival: {current.ArrivalTime}, Departure: {current.DepartureTime}");
            }
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        AttendanceSystem attendanceSystem = new AttendanceSystem();

        // يمكنك تعديل أو إضافة المزيد من الموظفين هنا
        attendanceSystem.RecordAttendance("Ahmed", DateTime.Parse("2024-02-28"), TimeSpan.Parse("09:00"), TimeSpan.Parse("17:00"));
        attendanceSystem.RecordAttendance("hashem", DateTime.Parse("2024-02-28"), TimeSpan.Parse("08:30"), TimeSpan.Parse("16:30"));
        attendanceSystem.RecordAttendance("ali", DateTime.Parse("2024-03-01"), TimeSpan.Parse("10:00"), TimeSpan.Parse("18:00"));

        Console.Write("Enter employee name: ");
        string selectedEmployee = Console.ReadLine();

        Console.WriteLine($"\nAttendance Records for {selectedEmployee}:");
        attendanceSystem.DisplayAttendanceForEmployee(selectedEmployee);
    }
}
