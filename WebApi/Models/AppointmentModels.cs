using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Disease { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string RecurrenceRule { get; set; }
        public string Symptoms { get; set; }
        public bool? IsAllDay { get; set; }
        public string ElementType { get; set; }
        public bool IsBlock { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }

        public Hospital() { }

        public Hospital(int Id, string Name, DateTime StartTime, DateTime EndTime, string Disease, string DepartmentName, int DepartmentId, int DoctorId, int PatientId, string Symptoms)
        {
            this.Id = Id;
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Disease = Disease;
            this.DepartmentName = DepartmentName;
            this.DepartmentId = DepartmentId;
            this.DoctorId = DoctorId;
            this.PatientId = PatientId;
            this.Symptoms = Symptoms;
        }

  
    }

    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a valid name.")]
        public string Name { get; set; }
        public string Text { get; set; }
        [Required(ErrorMessage = "Select a valid DOB.")]
        public DateTime? DOB { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Enter a valid mobile number.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "A valid email address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "A valid email address is required.")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Disease { get; set; }
        public string DepartmentName { get; set; }
        [Required]
        public string BloodGroup { get; set; } = "AB +ve";
        public string Gender { get; set; } = "Male";
        public string Symptoms { get; set; }
        public Patient()
        {

        }

        public Patient(int Id, string Name, string Text, DateTime? DOB, string Mobile, string Email, string Address, string Disease, string DepartmentName, string BloodGroup, string Gender, string Symptoms)
        {
            this.Id = Id;
            this.Name = Name;
            this.Text = Text;
            this.DOB = DOB;
            this.Mobile = Mobile;
            this.Email = Email;
            this.Address = Address;
            this.Disease = Disease;
            this.DepartmentName = DepartmentName;
            this.BloodGroup = BloodGroup;
            this.Gender = Gender;
            this.Symptoms = Symptoms;
        }

       

    }
    public class Appointment
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public string DoctorName { get; set; }
        public string Symptoms { get; set; }
        public int DoctorId { get; set; }

        public Appointment() { }

        public Appointment(string Time, string Name, string DoctorName, string Symptoms, int DoctorId)
        {
            this.Time = Time;
            this.Name = Name;
            this.DoctorName = DoctorName;
            this.Symptoms = Symptoms;
            this.DoctorId = DoctorId;
        }
    }

    public class Doctor
    {
        [Required(ErrorMessage = "Enter a valid name.")]
        public string Name { get; set; }
        public string Gender { get; set; } = "Male";
        public string Text { get; set; }
        public int Id { get; set; }
        public int DepartmentId { get; set; } = 1;
        public string Color { get; set; }
        public string Education { get; set; }
        public string Specialization { get; set; } = "generalmedicine";
        public string Experience { get; set; } = "1+ years";
        public string Designation { get; set; }
        public string DutyTiming { get; set; } = "Shift1";
        [Required(ErrorMessage = "A valid email address is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "A valid email address is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter a valid mobile number.")]
        public string Mobile { get; set; }
        public string Availability { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        [NotMapped]
        public int[] AvailableDays { get; set; }
        public List<WorkDay> WorkDays { get; set; }

        public Doctor() { }

        public Doctor(string Name, string Gender, string Text, int Id, int DepartmentId, string Color, string Education, string Specialization, string Experience, string Designation, string DutyTiming, string Email, string Mobile, string Availability, string StartHour, string EndHour, int[] AvailableDays, List<WorkDay> WorkDays)
        {
            this.Name = Name;
            this.Gender = Gender;
            this.Text = Text;
            this.Id = Id;
            this.DepartmentId = DepartmentId;
            this.Color = Color;
            this.Education = Education;
            this.Specialization = Specialization;
            this.Experience = Experience;
            this.Designation = Designation;
            this.DutyTiming = DutyTiming;
            this.Email = Email;
            this.Mobile = Mobile;
            this.Availability = Availability;
            this.StartHour = StartHour;
            this.EndHour = EndHour;
            this.AvailableDays = AvailableDays;
            this.WorkDays = WorkDays;
        }

    }

    public class WorkDay
    {
        public string Day { get; set; }
        [Key]
        public int Index { get; set; }
        public bool Enable { get; set; }
        public DateTime? WorkStartHour { get; set; }
        public DateTime? WorkEndHour { get; set; }
        [Required(ErrorMessage = "Enter valid Hour")]
        public DateTime? BreakStartHour { get; set; } = new DateTime(2020, 2, 01, 12, 0, 0);
        [Required(ErrorMessage = "Enter valid Hour")]
        public DateTime? BreakEndHour { get; set; } = new DateTime(2020, 2, 01, 13, 0, 0);
        public string State { get; set; }

        public WorkDay() { }

        public WorkDay(string Day, int Index, bool Enable, DateTime? WorkStartHour, DateTime? WorkEndHour, DateTime? BreakStartHour, DateTime? BreakEndHour, string State)
        {
            this.Day = Day;
            this.Index = Index;
            this.Enable = Enable;
            this.WorkStartHour = WorkStartHour;
            this.WorkEndHour = WorkEndHour;
            this.BreakStartHour = BreakStartHour;
            this.BreakEndHour = BreakEndHour;
            this.State = State;
        }
    }

    public class WaitingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Disease { get; set; }
        public string DepartmentName { get; set; }
        public string Treatment { get; set; }
        public int DepartmentId { get; set; }
        public int PatientId { get; set; }

 
    }

    public class Specialization
    {
        public int? DepartmentId { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }

        public Specialization() { }

        public Specialization(int? DepartmentId, string Id, string Text, string Color)
        {
            this.DepartmentId = DepartmentId;
            this.Id = Id;
            this.Text = Text;
            this.Color = Color;
        }



    }


    public class TextIdData
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public TextIdData() { }

        public TextIdData(string Id, string Text)
        {
            this.Id = Id;
            this.Text = Text;
        }

        public List<TextIdData> ExperienceData()
        {
            List<TextIdData> data = new List<TextIdData>
            {
                new TextIdData("1+ years", "1+ years"),
                new TextIdData("2+ years", "2+ years"),
                new TextIdData("5+ years", "5+ years"),
                new TextIdData("10+ years", "10+ years"),
                new TextIdData("15+ years", "15+ years"),
                new TextIdData("20+ years", "20+ years")
            };
            return data;
        }
        public List<TextIdData> DutyTimingsData()
        {
            List<TextIdData> data = new List<TextIdData>
            {
                new TextIdData("Shift1", "08:00 AM - 5:00 PM"),
                new TextIdData("Shift2", "10:00 AM - 7:00 PM"),
                new TextIdData("Shift3", "12:00 PM - 9:00 PM")
            };
            return data;
        }
    }

    public class TextValueData
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public TextValueData() { }

        public TextValueData(string Value, string Text)
        {
            this.Value = Value;
            this.Text = Text;
        }

        public List<TextValueData> GetStartHours()
        {
            List<TextValueData> data = new List<TextValueData>
            {
                new TextValueData("08:00", "8.00 AM"),
                new TextValueData("9:00", "9.00 AM"),
                new TextValueData("10:00", "10.00 AM"),
                new TextValueData("11:00", "11.00 AM"),
                new TextValueData("12:00", "12.00 AM")
            };
            return data;
        }
        public List<TextValueData> GetEndHours()
        {
            List<TextValueData> data = new List<TextValueData>
            {
                new TextValueData("16:00", "4.00 PM"),
                new TextValueData("17:00", "5.00 PM"),
                new TextValueData("18:00", "6.00 PM"),
                new TextValueData("19:00", "7.00 PM"),
                new TextValueData("20:00", "8.00 PM"),
                new TextValueData("21:00", "9.00 PM")
            };
            return data;
        }
        public List<TextValueData> GetViews()
        {
            List<TextValueData> data = new List<TextValueData>
            {
                new TextValueData("Day", "Daily"),
                new TextValueData("Week", "Weekly"),
                new TextValueData("Month", "Monthly")
            };
            return data;
        }
        public List<TextValueData> GetColorCategory()
        {
            List<TextValueData> data = new List<TextValueData>
            {
                new TextValueData("Departments", "Department Colors"),
                new TextValueData("Doctors", "Doctors Colors")
            };
            return data;
        }
        public List<TextValueData> GetBloodGroupData()
        {
            List<TextValueData> data = new List<TextValueData>
            {
                new TextValueData("AB +ve", "AB +ve"),
                new TextValueData("A +ve", "A +ve"),
                new TextValueData("B +ve", "B +ve"),
                new TextValueData("O +ve", "O +ve"),
                new TextValueData("AB -ve", "AB -ve"),
                new TextValueData("A -ve", "A -ve"),
                new TextValueData("B -ve", "B -ve"),
                new TextValueData("O -ve", "O -ve")
            };
            return data;
        }
    }
    public class TextValueNumericData
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public TextValueNumericData() { }

        public TextValueNumericData(int Value, string Text)
        {
            this.Value = Value;
            this.Text = Text;
        }

        public List<TextValueNumericData> GetTimeSlot()
        {
            List<TextValueNumericData> data = new List<TextValueNumericData>
            {
                new TextValueNumericData(10, "10 mins"),
                new TextValueNumericData(20, "20 mins"),
                new TextValueNumericData(30, "30 mins"),
                new TextValueNumericData(60, "60 mins"),
                new TextValueNumericData(120, "120 mins")
            };
            return data;
        }

        public List<TextValueNumericData> GetDayOfWeekList()
        {
            List<TextValueNumericData> data = new List<TextValueNumericData>
            {
                new TextValueNumericData(0, "Sunday"),
                new TextValueNumericData(1, "Monday"),
                new TextValueNumericData(2, "Tuesday"),
                new TextValueNumericData(3, "Wednesday"),
                new TextValueNumericData(4, "Thursday"),
                new TextValueNumericData(5, "Friday"),
                new TextValueNumericData(6, "Saturday")
            };
            return data;
        }
    }
    public class Activity
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public DateTime ActivityTime { get; set; }

        public Activity() { }

        public Activity(string Name, string Message, string Time, string Type, DateTime ActivityTime)
        {
            this.Name = Name;
            this.Message = Message;
            this.Time = Time;
            this.Type = Type;
            this.ActivityTime = ActivityTime;
        }
        public List<Activity> GetActivityData()
        {
            List<Activity> data = new List<Activity>
            {
                new Activity("Added New Doctor", "Dr.Johnson James, Cardiologist", "5 mins ago", "doctor", new DateTime(2020, 2, 1, 9, 0, 0)),
                new Activity("Added New Appointment", "Laura for General Checkup on 7th March, 2020 @ 8.30 AM with Dr.Molli Cobb, Cardiologist", "5 mins ago", "appointment", new DateTime(2020, 2, 1, 11, 0, 0)),
                new Activity("Added New Patient", "James Richard for Fever and cold", "5 mins ago", "patient", new DateTime(2020, 2, 1, 10, 0, 0)),
                new Activity("Added New Appointment", "Joseph for consultation on 7th Feb, 2020 @ 11.10 AM with Dr.Molli Cobb", "5 mins ago", "appointment", new DateTime(2020, 2, 1, 11, 0, 0))
            };
            return data;
        }
    }

    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string RecurrenceRule { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsBlock { get; set; }
        public int[] DoctorId { get; set; }

        public Block() { }

        public Block(int Id, string Name, string StartTime, string EndTime, string RecurrenceRule, bool IsAllDay, bool IsBlock, int[] DoctorId)
        {
            this.Id = Id;
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.RecurrenceRule = RecurrenceRule;
            this.IsAllDay = IsAllDay;
            this.IsBlock = IsBlock;
            this.DoctorId = DoctorId;

        }
    }
    public class ChartData
    {
        public DateTime Date { get; set; }
        public int? EventCount { get; set; }
    }

    public class NavigationMenu
    {
        public string Text { get; set; }
        public string Value { get; set; } = "dashboard";
        public string Icon { get; set; }

        public NavigationMenu() { }

        public NavigationMenu(string Text, string Value, string Icon)
        {
            this.Text = Text;
            this.Value = Value;
            this.Icon = Icon;
        }
        public List<NavigationMenu> GetNavigationMenuItems()
        {
            List<NavigationMenu> data = new List<NavigationMenu>
            {
                new NavigationMenu("Dashboard", "dashboard", "icon-dashboard"),
                new NavigationMenu("Schedule", "schedule", "icon-schedule"),
                new NavigationMenu("Doctors", "doctors", "icon-doctors"),
                new NavigationMenu("Patients", "patients", "icon-patients"),
                new NavigationMenu("Preference", "preference", "icon-preference"),
                new NavigationMenu("About", "about", "icon-about")
            };
            return data;
        }
    }
    public class CalendarSetting
    {
        public string BookingColor { get; set; }
        public Calendar Calendar { get; set; }
        public string CurrentView { get; set; }
        public int Interval { get; set; } = 60;
        public int FirstDayOfWeek { get; set; } = 1;
    }

    public class Calendar
    {
        public string Start { get; set; }
        public string End { get; set; }
        public bool? Highlight { get; set; }
    }
    public class TemplateArgs
    {
        public string ElementType { get; set; }
        public DateTime? Date { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Disease { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Symptoms { get; set; }
    }

    public class TimeSheetGroupData
    {
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
    }

}