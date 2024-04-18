// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyAdR7FWi3xnRxceaAaN33CKhwujVfGD7AY",
  authDomain: "pai-de-pet-8dc85.firebaseapp.com",
  projectId: "pai-de-pet-8dc85",
  storageBucket: "pai-de-pet-8dc85.appspot.com",
  messagingSenderId: "233417328207",
  appId: "1:233417328207:web:c3ee1726baddba2a54cc3a",
  measurementId: "G-S2N4L5LHLV"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);