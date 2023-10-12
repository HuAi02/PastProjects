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
import javagroup70.AdminReservations;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

public class Reservation {
    private Object[][] reservationList;
    private int numLines, newID;
    File reservations = new File("reservation.txt");

    public Reservation() {
        try (LineNumberReader reader = new LineNumberReader(new FileReader(reservations))) {
            reader.skip(Long.MAX_VALUE);
            numLines = reader.getLineNumber();
        } catch (IOException e) {
        }

        // Heading and data needed for table
        reservationList = new Object[numLines][10];

        // Read data of rooms from file
        BufferedReader br = null;
        String line;
        int i = 0;

        try {
            br = new BufferedReader(new FileReader(reservations));
        } catch (FileNotFoundException ex) {
            Logger.getLogger(AdminReservations.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            // Read each line and split it into fields
            while ((line = br.readLine()) != null) {
                String[] fields = line.split(",");
                reservationList[i][0] = fields[0].trim();
                reservationList[i][1] = fields[1].trim();
                reservationList[i][2] = fields[2].trim();
                reservationList[i][3] = fields[3].trim();
                reservationList[i][4] = fields[4].trim();
                reservationList[i][5] = fields[5].trim();
                reservationList[i][6] = fields[6].trim();
                reservationList[i][7] = fields[7].trim();
                reservationList[i][8] = fields[8].trim();
                reservationList[i][9] = fields[9].trim();
                i++;
            }
            br.close();
        } catch (IOException ex) {
            Logger.getLogger(Reservation.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] getReservationList() {
        return reservationList;
    }
    
    public Object[][] getReservationList(String passport){
        int filteredRowCount = 0;
        for (Object[] row : reservationList) {
            if (row[2].equals(passport)) {
                filteredRowCount++;
            }
        }
    
        Object[][] filteredReservation = new Object[filteredRowCount][reservationList[0].length];
        int filteredRowIndex = 0;
        for (Object[] row : reservationList) {
            if (row[2].equals(passport)) {
                filteredReservation[filteredRowIndex] = row;
                filteredRowIndex++;
            }
        }
        return filteredReservation;
    }
    public Object[][] getReservationList(String passport, String status){
        int filteredRowCount = 0;
        for (Object[] row : reservationList) {
            if (row[2].equals(passport)&&row[9].equals(status) ) {
                filteredRowCount++;
            }
        }
    
        Object[][] filteredReservation = new Object[filteredRowCount][reservationList[0].length];
        int filteredRowIndex = 0;
        for (Object[] row : reservationList) {
            if (row[2].equals(passport)&&row[9].equals(status)) {
                filteredReservation[filteredRowIndex] = row;
                filteredRowIndex++;
            }
        }
        return filteredReservation;
    }

    public void setReservationElement(int row, int col, String value) {
        this.reservationList[row][col] = value;
        try {
            FileWriter fwrite = new FileWriter(reservations, false);
            for (int k = 0; k < reservationList.length; k++) {
                for (int l = 0; l < reservationList[k].length; l++) {
                    if (k == row && l == col) {
                        fwrite.write(value + ",");
                    } else {
                        fwrite.write((String) reservationList[k][l] + ",");
                    }
                }
                fwrite.write(System.lineSeparator());
            }
            fwrite.close();
        } catch (IOException ex) {
            Logger.getLogger(Reservation.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] addRow(String data1, String data2, String data3, String data4) {
        // Create a new array with an additional row
        Object[][] newArray = new Object[reservationList.length + 1][reservationList[0].length];
        
        // Copy the values from the existing array to the new array
        for (int i = 0; i < reservationList.length; i++) {
            System.arraycopy(reservationList[i], 0, newArray[i], 0, reservationList[i].length);
        }
        
        try {
            // Open the file for reading
            BufferedReader br0 = new BufferedReader(new FileReader(reservations));

            // Read the file line by line and find the largest ID
            String line;
            int maxID = 0;
            while ((line = br0.readLine()) != null) {
                String[] parts = line.split(",");
                int id = Integer.parseInt(parts[0]);
                if (id > maxID) {
                    maxID = id;
                }
            }

            // Close the file
            br0.close();

            // Set the new ID as the largest ID + 1
            newID = maxID + 1;

        } catch (IOException e) {
            // Handle the exception
            e.printStackTrace();
        }
        
        // Define the input and output date formats
        String inputDateFormat = "dd/MM/yyyy";
        String outputDateFormat = "dd/MM/yyyy";

        // Parse the input string to a LocalDate object using the input format
        LocalDate date1 = LocalDate.parse(data3, DateTimeFormatter.ofPattern(inputDateFormat));

        // Format the LocalDate object to a string using the output format
        String date = date1.format(DateTimeFormatter.ofPattern(outputDateFormat));
        
        // Get the month value (1-12)
        int month = date1.getMonthValue();
        int year = date1.getYear();
        int days = 0;
        
        switch (month){
            case 1,3,5,7,8,10,12 -> days = 31;
            case 2 -> {
                if (year%4!=0 && year%100!=0) {
                    // not leap year
                    days = 28;
                } else if (year%4==0 && year%100!=0) {
                    // leap year
                    days = 29;
                } else if (year%400!=0 && year%100!=0) {
                    // century but not leap year
                    days = 28;
                } else if (year%400==0) {
                    // century leap year
                    days = 29;
                } else {
                    days = 28;
                }
            }
            case 4,6,9,11 -> days = 30;
        }
        
        // Calculate the final date
        String finalDate;
        if (month > 12){
            month-=12;
            year+=1;
        }
        finalDate = String.valueOf(days)+"/"+String.valueOf(month)+"/"+String.valueOf(year);
        int pricing = 0;
        
        try {
            // Open the file for reading
            BufferedReader br1 = new BufferedReader(new FileReader("room.txt"));

            // Read the file line by line and find the price for that room ID
            String line;
            boolean found = false;
            while ((line = br1.readLine()) != null && !found) {
                String[] parts = line.split(",");
                if (parts[0].equals(data1)){
                    pricing = Integer.parseInt(parts[4]);
                    found = true;
                }
            }

            // Close the file
            br1.close();

            // Use the pricing variable as needed
        } catch (IOException e) {
            // Handle the exception
        }
        
        // Calculate payment left
        int toPay = Integer.parseInt(data4) * pricing;
        
        newArray[newArray.length - 1] = new Object[]{newID ,data1, data2, date, finalDate, data4, data4, toPay , pricing, "Pending"};
        reservationList = newArray;

        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(reservations));
            for (Object[] newArray1 : newArray) {
                for (Object newArray11 : newArray1) {
                    bwriter.write(newArray11 + ",");
                }
                bwriter.write(System.lineSeparator());
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(RoomList.class.getName()).log(Level.SEVERE, null, ex);
        }

        return reservationList;
    }

    public Object[][] deleteRow(int row) {
        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(reservations));
            for (int i = 0; i < reservationList.length; i++) {
                if (i == row) {
                } else {
                    for (int j = 0; j < 10; j++) {
                        bwriter.write((String) reservationList[i][j] + ",");
                    }
                    bwriter.write(System.lineSeparator());
                }
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(RoomList.class.getName()).log(Level.SEVERE, null, ex);
        }
        return reservationList;
    }
}
