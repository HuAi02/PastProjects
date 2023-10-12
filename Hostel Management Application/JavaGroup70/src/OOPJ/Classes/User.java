package OOPJ.Classes;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
import javax.swing.JOptionPane;

public class User {

    private static String username, password, role, passport, firstName, lastName, age, gender, contact;

    public static String getFirstName() {
        return firstName;
    }

    public static void setFirstName(String firstName) {
        User.firstName = firstName;
    }

    public static String getAge() {
        return age;
    }

    public static void setAge(String age) {
        User.age = age;
    }

    public static String getGender() {
        return gender;
    }

    public static void setGender(String gender) {
        User.gender = gender;
    }

    public static String getContact() {
        return contact;
    }

    public static void setContact(String contact) {
        User.contact = contact;
    }

    public static String getLastName() {
        return lastName;
    }

    public static void setLastName(String lastName) {
        User.lastName = lastName;
    }

    public static String getPassport() {
        return passport;
    }

    public static void setPassport(String passport) {
        User.passport = passport;
    }

    public static String getUsername() {
        return username;
    }

    public static void setUsername(String username) {
        User.username = username;
    }

    public static String getPassword() {
        return password;
    }

    public static void setPassword(String password) {
        User.password = password;
    }

    public static String getRole() {
        return role;
    }

    public static void setRole(String role) {
        User.role = role;
    }
    
    public static void updateProfile(String data1, String data2, String data3, String data4){
        String file = "user.txt";
        String[] parts;
        String rowToUpdate = null;

        try {
            // Read the contents of the file into a List
            List<String> content = Files.readAllLines(Paths.get(file));

            // Find the row with the specified passport number
            for (String line : content) {
                parts = line.split(",");
                if (User.getPassport().equals(parts[0])) {
                    rowToUpdate = line;
                    break;
                }
            }

            // Update the row if it exists
            if (rowToUpdate != null) {
                parts = rowToUpdate.split(",");
                parts[8] = data2;
                parts[4] = data3;
                parts[7] = data4;
                String newLine = String.join(",", parts);

                // Update the List with the modified row
                int index = content.indexOf(rowToUpdate);
                content.set(index, newLine);

                // Write the modified List back to the file
                String newFile = "user.txt";
                Files.write(Paths.get(newFile), content, StandardCharsets.UTF_8);
                JOptionPane.showMessageDialog(null, "Update Success!");
            } 
            else {
                JOptionPane.showMessageDialog(null, "Update Fail");
            }
                
        } 
        catch (IOException e) {
            e.printStackTrace();
            JOptionPane.showMessageDialog(null, "Error");
        }
    }
}
