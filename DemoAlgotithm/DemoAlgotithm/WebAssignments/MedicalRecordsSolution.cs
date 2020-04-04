using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.WebAssignments
{
    public class MedicalRecordsSolution
    {
        public static List<int> getRecordsByAgeGroup(int ageStart, int ageEnd, int bpDiff)
        {
            var medicalRecords = GetAllMedicalRecord().Result;
            var filteredMedicalRecordIds = FilterMedicalRecordByConditions(ageStart, ageEnd, bpDiff, medicalRecords);
            
            if (filteredMedicalRecordIds.Count <= 0)
            {
                return new List<int>() { -1 };
            }

            return filteredMedicalRecordIds;
        }

        public static List<int> FilterMedicalRecordByConditions(int ageStart, int ageEnd, int bpDiff, List<MedicalRecord> medicalRecords)
        {
            if (medicalRecords == null || medicalRecords.Count == 0)
            {
                return new List<int>();
            }

            List<int> filteredRecords = new List<int>();
            double age = 0;

            foreach (var record in medicalRecords)
            {
                //It's close enough for most of the cases.
                age = (DateTime.UtcNow - (new DateTime(1997, 1, 1, 0, 0, 0, 0).AddTicks(record.timestamp))).TotalDays /365.25;

                if ((age >= ageStart && age <= ageEnd)
                    && (record.vitals.bloodPressureDiastole - record.vitals.bloodPressureSystole) > bpDiff)
                {
                    filteredRecords.Add(record.id);
                }
            }

            return filteredRecords;
        }

        public static async Task<List<MedicalRecord>> GetAllMedicalRecord()
        {
            List<MedicalRecord> medicalRecords = null;
            List<Task<MedicalRecordResponse>> tasks = null;
            
            //The first request for total records and total pages.
            var firstMedicalResponse = await GetMedicalRecordsResponseByPage(1);
            medicalRecords = new List<MedicalRecord>(firstMedicalResponse.total);
            medicalRecords.AddRange(firstMedicalResponse.data);

            tasks = new List<Task<MedicalRecordResponse>>(firstMedicalResponse.total_pages);

            //start from 2.
            for (int i = 2; i <= firstMedicalResponse.total_pages; i++)
            {
                tasks.Add(GetMedicalRecordsResponseByPage(i));
            }

            var responses = await Task.WhenAll(tasks);

            for (int i = 0; i < responses.Length; i++)
            {
                medicalRecords.AddRange(responses[i].data);
            }

            return medicalRecords;
        }

        public static async Task<MedicalRecordResponse> GetMedicalRecordsResponseByPage(int page)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonmock.hackerrank.com");
            client.Timeout = TimeSpan.FromSeconds(3);

            MedicalRecordResponse medicalRecordResponse = new MedicalRecordResponse();
            HttpResponseMessage httpRes = await client.GetAsync($"/api/medical_records?page={page}");

            if (httpRes.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<MedicalRecordResponse>(await httpRes.Content.ReadAsStringAsync());
            }

            return new MedicalRecordResponse();
        }

        public class Diagnosis
        {
            public int id { get; set; }
            public string name { get; set; }
            public int severity { get; set; }
        }

        public class Vitals
        {
            public int bloodPressureDiastole { get; set; }
            public int bloodPressureSystole { get; set; }
            public int pulse { get; set; }
            public int breathingRate { get; set; }
            public double bodyTemperature { get; set; }
        }

        public class Doctor
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Meta
        {
            public int height { get; set; }
            public int weight { get; set; }
        }

        public class MedicalRecord
        {
            public int id { get; set; }
            public long timestamp { get; set; }
            public Diagnosis diagnosis { get; set; }
            public Vitals vitals { get; set; }
            public Doctor doctor { get; set; }
            public int userId { get; set; }
            public string userName { get; set; }
            public string userDob { get; set; }
            public Meta meta { get; set; }
            public int age { get; set; }
        }

        public class MedicalRecordResponse
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<MedicalRecord> data { get; set; }
        }
    }
}
