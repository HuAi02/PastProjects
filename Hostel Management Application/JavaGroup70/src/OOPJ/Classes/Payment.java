package OOPJ.Classes;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.LineNumberReader;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Calendar;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Payment {
    private Object[][] paymentList;
    private int numLines;
    private String userame, password, anotherNumLines;
    File payment = new File("payment.txt");

    public Payment() {
        try (LineNumberReader reader = new LineNumberReader(new FileReader(payment))) {
            reader.skip(Long.MAX_VALUE);
            numLines = reader.getLineNumber();
        } catch (IOException e) {
        }

        // Heading and data needed for table
        paymentList = new Object[numLines][5];

        // Read data of rooms from file
        BufferedReader br = null;
        String line;
        int i = 0;

        try {
            br = new BufferedReader(new FileReader(payment));
        } catch (FileNotFoundException ex) {
        }
        try {
            // Read each line and split it into fields
            while ((line = br.readLine()) != null) {
                String[] fields = line.split(",");
                paymentList[i][0] = fields[0];
                paymentList[i][1] = fields[1];
                paymentList[i][2] = fields[2];
                paymentList[i][3] = fields[3];
                paymentList[i][4] = fields[4];
                i++;
            }
            br.close();
        } catch (IOException ex) {
            Logger.getLogger(Payment.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] getPaymentList() {
        return paymentList;
    }

    public Object[][] addRow(String data1, String data2, String data3) throws FileNotFoundException, IOException {
        // Create a new array with an additional row
        Object[][] newArray = new Object[paymentList.length + 1][paymentList[0].length];

        // Get current date
        LocalDate date = LocalDate.now();

        // Format date and time using a DateTimeFormatter object
        DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        String formattedDate = date.format(dateFormatter);
        
        BufferedReader br0 = new BufferedReader(new FileReader(payment));
        
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

        // Copy the values from the existing array to the new array
        for (int i = 0; i < paymentList.length; i++) {
        System.arraycopy(paymentList[i], 0, newArray[i], 0, paymentList[i].length);
        }

        // Add new row with formatted date and time
        newArray[newArray.length - 1] = new Object[]{maxID, data1, data2, formattedDate, data3};
        paymentList = newArray;

        // Write updated data to file
        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(payment));
            for (int i = 0; i < newArray.length; i++) {
                for (int j = 0; j < newArray[i].length; j++) {
                    bwriter.write(newArray[i][j] + ",");
                }
                bwriter.write(System.lineSeparator());
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(Payment.class.getName()).log(Level.SEVERE, null, ex);
        }

        return paymentList;
    }
    
    public Object[][] makeReport(String month, String year) throws ParseException{
        // Create a new 2D array with 3 rows and 3 columns
        Object[][] newArray = new Object[paymentList.length][paymentList[0].length-1];

        // Copy the values from the original array to the new array
        for (int i = 0; i < paymentList.length; i++) {
            // create a SimpleDateFormat object to parse the string date
            SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");

            // parse the string date and create a Date object
            String dateString = (String) paymentList[i][3];
            Date date = dateFormat.parse(dateString);

            // create a Calendar object and set its time to the Date object
            Calendar calendar = Calendar.getInstance();
            calendar.setTime(date);

            // extract the month and year from the Calendar object
            int extractedMonth = calendar.get(Calendar.MONTH);
            int extractedYear = calendar.get(Calendar.YEAR);
            extractedMonth+=1; // add 1 because month is zero-indexed
            if (extractedMonth==Integer.parseInt(month) && extractedYear==Integer.parseInt(year)){
                newArray[i][0] = paymentList[i][0];
                newArray[i][1] = paymentList[i][2];
                newArray[i][2] = paymentList[i][3];
                newArray[i][3] = paymentList[i][4];
            }
        }
        anotherNumLines = String.valueOf(newArray.length);
        return newArray;
    }
}
