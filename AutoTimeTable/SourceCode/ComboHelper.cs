using System.Data;
using System.Windows.Forms;

namespace AutoTimeTable.SourceCode
{
    public class ComboHelper
    {
        public static void SmesterComboBox(ComboBox cmb)
        {
            DataTable dtSmester = new DataTable();
            dtSmester.Columns.Add("SmesterId");
            dtSmester.Columns.Add("SmesterName");
            dtSmester.Rows.Add("0", " -----Select-----");
 
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select SmesterId,SmesterName from SmesterTable where isActive='1'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow smester in dt.Rows)
                        {
                            dtSmester.Rows.Add(smester["SmesterId"], smester["SmesterName"]);
                        }
                    }
                }
                cmb.DataSource = dtSmester;
                cmb.ValueMember = "SmesterId";
                cmb.DisplayMember = "SmesterName";
            }
            catch
            {
                cmb.DataSource = dtSmester;
            }
        }
        public static void ProgramComboBox(ComboBox cmb)
        {
            DataTable dtProgram= new DataTable();
            dtProgram.Columns.Add("ProgramId");
            dtProgram.Columns.Add("Title");
            dtProgram.Rows.Add("0", " -----Select-----");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select ProgramId,Title from ProgramTable where isActive='1'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow program in dt.Rows)
                        {
                            dtProgram.Rows.Add(program["ProgramId"], program["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtProgram;
                cmb.ValueMember = "ProgramId";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtProgram;
            }
        }
        public static void RoomTypesComboBox(ComboBox cmb)
        {
            DataTable dtRoomType= new DataTable();
            dtRoomType.Columns.Add("RoomTypeID");
            dtRoomType.Columns.Add("TypeName");
            dtRoomType.Rows.Add("0", " -----Select-----");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select RoomTypeID,TypeName from RoomTypeTable ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtRoomType.Rows.Add(type["RoomTypeID"], type["TypeName"]);
                        }
                    }
                }
                cmb.DataSource = dtRoomType;
                cmb.ValueMember = "RoomTypeID";
                cmb.DisplayMember = "TypeName";
            }
            catch
            {
                cmb.DataSource = dtRoomType;
            }
        }
        public static void AllDaysComboBox(ComboBox cmb)
        {
            DataTable dtDays= new DataTable();
            dtDays.Columns.Add("DayId");
            dtDays.Columns.Add("Name");
            dtDays.Rows.Add("0", " -----Select-----");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select DayId,Name from DayTable where isActive='1' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow days in dt.Rows)
                        {
                            dtDays.Rows.Add(days["DayId"], days["Name"]);
                        }
                    }
                }
                cmb.DataSource = dtDays;
                cmb.ValueMember = "DayId";
                cmb.DisplayMember = "Name";
            }
            catch
            {
                cmb.DataSource = dtDays;
            }
        }
        public static void TimeSlotNumberComboBox(ComboBox cmb)
        {
            DataTable dtDays = new DataTable();
            dtDays.Columns.Add("Id");
            dtDays.Columns.Add("Number");
            dtDays.Rows.Add("0", "0");
            dtDays.Rows.Add("1", "1");
            dtDays.Rows.Add("2", "2");
            dtDays.Rows.Add("3", "3");
            dtDays.Rows.Add("4", "4");
            dtDays.Rows.Add("5", "5");
            dtDays.Rows.Add("6", "6");
            dtDays.Rows.Add("7", "7");
            dtDays.Rows.Add("8", "8");
            dtDays.Rows.Add("9", "9");
            dtDays.Rows.Add("10", "10");
            dtDays.Rows.Add("11", "11");
            dtDays.Rows.Add("12", "12");
            dtDays.Rows.Add("13", "13");
            dtDays.Rows.Add("14", "14");
            dtDays.Rows.Add("15", "15");
            dtDays.Rows.Add("16", "16");
            dtDays.Rows.Add("17", "17");
            dtDays.Rows.Add("18", "18");
            dtDays.Rows.Add("19", "19");
            dtDays.Rows.Add("20", "20");
            dtDays.Rows.Add("21", "21");
            dtDays.Rows.Add("22", "22");
            dtDays.Rows.Add("23", "23");
            dtDays.Rows.Add("24", "24");
            dtDays.Rows.Add("25", "25");
            dtDays.Rows.Add("26", "26");
            dtDays.Rows.Add("27", "27");
            dtDays.Rows.Add("28", "28");
            dtDays.Rows.Add("29", "29");
            dtDays.Rows.Add("30", "30");
            dtDays.Rows.Add("31", "31");
            dtDays.Rows.Add("32", "32");
            dtDays.Rows.Add("33", "33");
            dtDays.Rows.Add("34", "34");
            dtDays.Rows.Add("35", "35");
            dtDays.Rows.Add("36", "36");
            dtDays.Rows.Add("37", "37");
            dtDays.Rows.Add("38", "38");
            dtDays.Rows.Add("39", "39");
            dtDays.Rows.Add("40", "40");
            cmb.DataSource = dtDays;
            cmb.ValueMember = "Id";
            cmb.DisplayMember = "Number";
        }

        public static void AllTeachersComboBox(ComboBox cmb)
        {
            DataTable dtTeacher = new DataTable();
            dtTeacher.Columns.Add("LectureId");
            dtTeacher.Columns.Add("Fullname");
            dtTeacher.Rows.Add("0", " -----Select-----");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select LectureId,Fullname from LecturerTable where isActive='1' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow days in dt.Rows)
                        {
                            dtTeacher.Rows.Add(days["LectureId"], days["Fullname"]);
                        }
                    }
                }
                cmb.DataSource = dtTeacher;
                cmb.ValueMember = "LectureId";
                cmb.DisplayMember = "Fullname";
            }
            catch
            {
                cmb.DataSource = dtTeacher;
            }
        }
        public static void AllSubjectsComboBox(ComboBox cmb)
        {
            DataTable dtSubject = new DataTable();
            dtSubject.Columns.Add("CourseId");
            dtSubject.Columns.Add("Title");
            dtSubject.Rows.Add("0", " -----Select-----");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select CourseId,Title from CourseTable where isActive='1' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow days in dt.Rows)
                        {
                            dtSubject.Rows.Add(days["CourseId"], days["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtSubject;
                cmb.ValueMember = "CourseId";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtSubject;
            }
        }

        public static void AllProgramSmerterComboBox(ComboBox cmb)
        {
            DataTable dtSubject = new DataTable();
            dtSubject.Columns.Add("ProgramSmesterId");
            dtSubject.Columns.Add("Title");
            dtSubject.Rows.Add("0", " -----Select-----");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select ProgramSmesterId,Title from v_ProgramSmesteerActiveList where ProgramSemesterIsActive='1' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow days in dt.Rows)
                        {
                            dtSubject.Rows.Add(days["ProgramSmesterId"], days["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtSubject;
                cmb.ValueMember = "ProgramSmesterId";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtSubject;
            }
        }
        public static void AllTeacherSubjectComboBox(ComboBox cmb)
        {
            DataTable dtSubject = new DataTable();
            dtSubject.Columns.Add("LectureSubjectId");
            dtSubject.Columns.Add("SubjectTitle");
            dtSubject.Rows.Add("0", " -----Select-----");
            try
            {
                DataTable dt = DatabaseLayer.Retrieve("select LectureSubjectId,SubjectTitle from v_AllSubjectTeacher where isActive='1' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow days in dt.Rows)
                        {
                            dtSubject.Rows.Add(days["LectureSubjectId"], days["SubjectTitle"]);
                        }
                    }
                }
                cmb.DataSource = dtSubject;
                cmb.ValueMember = "LectureSubjectId";
                cmb.DisplayMember = "SubjectTitle";
            }
            catch
            {
                cmb.DataSource = dtSubject;
            }
        }






    }
}
