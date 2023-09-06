using System;

namespace Day14Tasks.Tasks
{
    [Serializable]
    public class ServiceRequest
    {
        private string _author;
        private string _problem;
        private DateTime _date;
        private bool _status;
        public string Author 
        { 
            get => _author;
            set => _author = value;
        }
        public string Problem 
        { 
            get => _problem;
            set => _problem = value;
        }
        public DateTime Date 
        { 
            get => _date;
            set => _date = value;
        }
        public bool Status 
        { 
            get => _status;
            set => _status = value;
        }
        public ServiceRequest(string author, string problem, DateTime date)
        {
            this._author = author;
            this._problem = problem;
            this._date = date;
        }
        public ServiceRequest()
        {

        }
    }
}