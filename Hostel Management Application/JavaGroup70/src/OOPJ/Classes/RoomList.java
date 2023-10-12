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
import java.util.logging.Level;
import java.util.logging.Logger;
import javagroup70.AdminRooms;

public class RoomList{

    private Object[][] roomList;
    private int numLines;
    private String anotherNumLines;
    File rooms = new File("room.txt");

    public RoomList() {
        try (LineNumberReader reader = new LineNumberReader(new FileReader(rooms))) {
            reader.skip(Long.MAX_VALUE);
            numLines = reader.getLineNumber();
        } catch (IOException e) {
        }

        // Heading and data needed for table
        roomList = new Object[numLines][6];

        // Read data of rooms from file
        BufferedReader br = null;
        String line;
        int i = 0;

        try {
            br = new BufferedReader(new FileReader(rooms));
        } catch (FileNotFoundException ex) {
            Logger.getLogger(AdminRooms.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            // Read each line and split it into fields
            while ((line = br.readLine()) != null) {
                String[] fields = line.split(",");
                roomList[i][0] = fields[0].trim();
                roomList[i][1] = fields[1].trim();
                roomList[i][2] = fields[2].trim();
                roomList[i][3] = fields[3].trim();
                roomList[i][4] = fields[4].trim();
                roomList[i][5] = fields[5].trim();
                i++;
            }
            br.close();
        } catch (IOException ex) {
            Logger.getLogger(RoomList.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] getRoomList() {
        return roomList;
    }
    
    public Object[][] getRoomList(String status){
        int filteredRowCount = 0;
        for (Object[] row : roomList) {
            if (row[5].equals(status)) {
                filteredRowCount++;
            }
        }
    
        Object[][] filteredRoomList = new Object[filteredRowCount][roomList[0].length];
        int filteredRowIndex = 0;
        for (Object[] row : roomList) {
            if (row[5].equals(status)) {
                filteredRoomList[filteredRowIndex] = row;
                filteredRowIndex++;
            }
        }
        return filteredRoomList;
    }

    public void setRoomElement(int row, int col, String value) {
        this.roomList[row][col] = value;
        try {
            FileWriter fwrite = new FileWriter(rooms, false);
            for (int k = 0; k < roomList.length; k++) {
                for (int l = 0; l < roomList[k].length; l++) {
                    if (k == row && l == col) {
                        fwrite.write(value + ",");
                    } else {
                        fwrite.write((String) roomList[k][l] + ",");
                    }
                }
                fwrite.write(System.lineSeparator());
            }
            fwrite.close();
        } catch (IOException ex) {
            Logger.getLogger(RoomList.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public Object[][] addRow(String data1, String data2, String data3, String data4, String data5, String data6) {
        // Create a new array with an additional row
        Object[][] newArray = new Object[roomList.length + 1][roomList[0].length];

        // Copy the values from the existing array to the new array
        for (int i = 0; i < roomList.length; i++) {
            System.arraycopy(roomList[i], 0, newArray[i], 0, roomList[i].length);
        }
        newArray[newArray.length - 1] = new Object[]{data1, data2, data3, data4, data5, data6};
        roomList = newArray;

        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(rooms));
            for (int i = 0; i < newArray.length; i++) {
                for (int j = 0; j < newArray[i].length; j++) {
                    bwriter.write(newArray[i][j] + ",");
                }
                bwriter.write(System.lineSeparator());
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(RoomList.class.getName()).log(Level.SEVERE, null, ex);
        }

        return roomList;
    }

    public Object[][] deleteRow(int row) {
        try {
            BufferedWriter bwriter = new BufferedWriter(new FileWriter(rooms));
            for (int i = 0; i < roomList.length; i++) {
                if (i == row) {
                } else {
                    for (int j = 0; j < 6; j++) {
                        bwriter.write((String) roomList[i][j] + ",");
                    }
                    bwriter.write(System.lineSeparator());
                }
            }
            bwriter.close();
        } catch (IOException ex) {
            Logger.getLogger(RoomList.class.getName()).log(Level.SEVERE, null, ex);
        }
        return roomList;
    }

    public Object[][] makeReport(String availability) throws ParseException {
    // Create a new 2D array with the same dimensions as roomList
    Object[][] newArray = new Object[roomList.length][4];

    // Copy the values from roomList to newArray if the availability matches
    for (int i = 0; i < roomList.length; i++) {
        if (roomList[i][5].equals(availability)) {
            newArray[i][0] = roomList[i][0];
            newArray[i][1] = roomList[i][1];
            newArray[i][2] = roomList[i][3];
            newArray[i][3] = roomList[i][5];
        }
    }
    return newArray;
}

    public String roomCount() {
        return anotherNumLines;
    }
}
