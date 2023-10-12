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
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.Calendar;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import javagroup70.AdminLogs;

public class Logs {
    private Object[][] logList;
    private int numLines;
    private String anotherNumLines;
    File logs = new File("log.txt");

    public Logs() {
        try (LineNumberReader reader = new LineNumberReader(new FileReader(logs))) {
            reader.skip(Long.MAX_VALUE);
            numLines = reader.getLineNumber();
        } catch (IOException e) {
        }

        // Heading and data needed for table
        logList = new Object[numLines][3];

        // Read data of rooms from file
        BufferedReader br = null;
        String line;
        int i = 0;

        try {
            br = new BufferedReader(new FileReader(logs));
        } catch (FileNotFoundException ex) {
            Logger.getLogger(AdminLogs.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            // Read each line and split it into fields
            while ((line = br.readLine()) != null) {
                String[] fields = line.split(",");
                logList[i][0] = fields[0];
                logList[i][1] = fields[1];
                logList[i][2] = fields[2];
                i++;
            }
            br.close();
        } catch (IOException ex) {
            Logger.getLogger(Logs.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] getLogList() {
        return logList;
    }

    public Object[][] addRow(String data1) {
        // Create a new array with an additional row
        Object[][] newArray = new Object[logList.length + 1][logList[0].length];

        // Get current date and time
        LocalDate date = LocalDate.now();
        LocalTime time = LocalTime.now();

        // Format date and time using a DateTimeFormatter object
        DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        DateTimeFormatter timeFormatter = DateTimeFormatter.ofPattern("HH:mm:ss");
        String formattedDate = date.format(dateFormatter);
        String formattedTime = time.format(timeFormatter);

        // Copy the values from the existing array to the new array
        for (int i = 0; i < logList.length; i++) {
        System.arraycopy(logList[i], 0, newArray[i], 0, logList[i].length);
        }

        // Add new row with formatted date and time
        newArray[newArray.length - 1] = new Object[]{data1, formattedDate, formattedTime};
        logList = newArray;

        // Write updated data to file
        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(logs));
            for (int i = 0; i < newArray.length; i++) {
                for (int j = 0; j < newArray[i].length; j++) {
                    bwriter.write(newArray[i][j] + ",");
                }
                bwriter.write(System.lineSeparator());
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(Logs.class.getName()).log(Level.SEVERE, null, ex);
        }

        return logList;
    }

    public Object[][] deleteRow(int row) {
        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(logs));
            for (int i = 0; i < logList.length; i++) {
                if (i == row) {
                } else {
                    for (int j = 0; j < 3; j++) {
                        bwriter.write((String) logList[i][j] + ",");
                    }
                    bwriter.write(System.lineSeparator());
                }
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(Logs.class.getName()).log(Level.SEVERE, null, ex);
        }
        return logList;
    }
    
    public Object[][] makeReport(String month, String year) throws ParseException{
        // Create a new 2D array with 3 rows and 3 columns
        Object[][] newArray = new Object[logList.length][logList[0].length];

        // Copy the values from the original array to the new array
        for (int i = 0; i < logList.length; i++) {
            for (int j = 0; j < logList[0].length; j++) {
                // create a SimpleDateFormat object to parse the string date
                SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");

                // parse the string date and create a Date object
                String dateString = (String) logList[i][1];
                Date date = dateFormat.parse(dateString);

                // create a Calendar object and set its time to the Date object
                Calendar calendar = Calendar.getInstance();
                calendar.setTime(date);

                // extract the month and year from the Calendar object
                int extractedMonth = calendar.get(Calendar.MONTH);
                int extractedYear = calendar.get(Calendar.YEAR);
                extractedMonth+=1; // add 1 because month is zero-indexed

                if (extractedMonth==Integer.parseInt(month) && extractedYear==Integer.parseInt(year)){
                    newArray[i][j] = logList[i][j];
                }
            }
        }
        anotherNumLines = String.valueOf(newArray.length);
        return newArray;
    }
    
    public String logCount() {
        return anotherNumLines;
    }
}
