

import axios from 'axios';

axios.defaults.baseURL = process.env.REACT_APP_API_URL; 

// הגדרת headers ברירת מחדל
axios.defaults.headers['Content-Type'] = 'application/json';

// interceptor לתפיסת שגיאות ב-response
axios.interceptors.response.use(
  (response) => response, // אם אין שגיאה, מחזירים את התגובה כרגיל
  (error) => {
    console.error('API Error:', error.response || error.message);
    if (error.response && error.response.status === 401) {
      // אם השגיאה היא 401, הפנה לדף התחברות
      window.location.href = '/login'; // לדף התחברות
    }
    return Promise.reject(error); // מחזירים את השגיאה הלאה
  }
);

// אם יש JWT ב-localStorage, הוסף אותו ל-header של כל בקשה
const token = sessionStorage.getItem('token');
if (token) {
  axios.defaults.headers['Authorization'] = `Bearer ${token}`;
}

const apiUrl = process.env.REACT_APP_API_URL;
console.log("apiUrl");
console.log(apiUrl);

export default {
  getTasks: async () => {
    try {
      console.log(apiUrl);
      const result = await axios.get(`${apiUrl}`);
      return result.data;
    } catch (error) {
      console.error("Error fetching tasks:", error);
      throw error; // אתה יכול לטפל בשגיאה בצד הלקוח אם יש צורך
    }
  },

  addTask: async (name) => {
    const newTask = {
      name: name,
      isComplete: false
    };

    try {
      await axios.post(`${apiUrl}`, newTask);  // Send task data to the server
    } catch (error) {
      console.error("Error adding task:", error);
      throw error; // טיפול בשגיאה
    }
  },

  setCompleted: async (id, isComplete) => {
    try {
      await axios.put(`${apiUrl}${id}`, { isComplete: isComplete });
    } catch (error) {
      console.error("Error updating task:", error);
      throw error; // טיפול בשגיאה
    }
  },

  deleteTask: async (id) => {
    try {
      await axios.delete(`${apiUrl}${id}`);
    } catch (error) {
      console.error("Error deleting task:", error);
      throw error; // טיפול בשגיאה
    }
  }
};
