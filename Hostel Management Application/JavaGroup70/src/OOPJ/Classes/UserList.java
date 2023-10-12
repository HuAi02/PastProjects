package OOPJ.Classes;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.LineNumberReader;
import java.util.logging.Level;
import java.util.logging.Logger;
import javagroup70.AdminUsers;

public class UserList {
    private Object[][] userList;
    private int numLines;
    File users = new File("user.txt");

    public UserList() {
        try (LineNumberReader reader = new LineNumberReader(new FileReader(users))) {
            reader.skip(Long.MAX_VALUE);
            numLines = reader.getLineNumber();
        } catch (IOException e) {
        }

        // Heading and data needed for table
        userList = new Object[numLines][9];

        // Read data of rooms from file
        BufferedReader br = null;
        String line;
        int i = 0;

        try {
            br = new BufferedReader(new FileReader(users));
        } catch (FileNotFoundException ex) {
            Logger.getLogger(AdminUsers.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            // Read each line and split it into fields
            while ((line = br.readLine()) != null) {
                String[] fields = line.split(",");
                userList[i][0] = fields[0].trim();
                userList[i][1] = fields[1].trim();
                userList[i][2] = fields[2].trim();
                userList[i][3] = fields[3].trim();
                userList[i][4] = fields[4].trim();
                userList[i][5] = fields[5].trim();
                userList[i][6] = fields[6].trim();
                userList[i][7] = fields[7].trim();
                userList[i][8] = fields[8].trim();
                i++;
            }
            br.close();
        } catch (IOException ex) {
            Logger.getLogger(UserList.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] getStudentList() {
        return userList;
    }

    public void setStudentElement(int row, int col, String value) {
        this.userList[row][col] = value;
        try {
            FileWriter fwrite = new FileWriter(users, false);
            for (int k = 0; k < userList.length; k++) {
                for (int l = 0; l < userList[k].length; l++) {
                    if (k == row && l == col) {
                        fwrite.write(value + ",");
                    } else {
                        fwrite.write((String) userList[k][l] + ",");
                    }
                }
                fwrite.write(System.lineSeparator());
            }
            fwrite.close();
        } catch (IOException ex) {
            Logger.getLogger(UserList.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] addRow(String data1, String data2, String data3, String data4, String data5, String data6, String data7, String data8, String data9) {
        // Create a new array with an additional row
        Object[][] newArray = new Object[userList.length + 1][userList[0].length];

        // Copy the values from the existing array to the new array
        for (int i = 0; i < userList.length; i++) {
            System.arraycopy(userList[i], 0, newArray[i], 0, userList[i].length);
        }
        newArray[newArray.length - 1] = new Object[]{data1, data2, data3, data4, data5, data6, data7, data8, data9};
        userList = newArray;

        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(users));
            for (int i = 0; i < newArray.length; i++) {
                for (int j = 0; j < newArray[i].length; j++) {
                    bwriter.write(newArray[i][j] + ",");
                }
                bwriter.write(System.lineSeparator());
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(UserList.class.getName()).log(Level.SEVERE, null, ex);
        }

        return userList;
    }

    public Object[][] deleteRow(int row) {
        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(users));
            for (int i = 0; i < userList.length; i++) {
                if (i == row) {
                } else {
                    for (int j = 0; j < 9; j++) {
                        bwriter.write((String) userList[i][j] + ",");
                    }
                    bwriter.write(System.lineSeparator());
                }
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(UserList.class.getName()).log(Level.SEVERE, null, ex);
        }
        return userList;
    }
}
