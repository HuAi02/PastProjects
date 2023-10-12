package javagroup70;

import OOPJ.Classes.RoomList;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.UIManager;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableModel;

public class AdminRooms extends JFrame implements ActionListener {

    private JButton add = new JButton("Add");
    private JButton update = new JButton("Update");
    private JButton delete = new JButton("Delete");
    private JButton cancel = new JButton("Cancel");
    private JPanel buttons = new JPanel();
    private JPanel tablePanel = new JPanel();
    private JPanel all = new JPanel();
    int selectedRow = 0;

    public AdminRooms() {
        // Set Nimbus Look and Feel
        try {
            for (UIManager.LookAndFeelInfo info : UIManager.getInstalledLookAndFeels()) {
                if ("Windows".equals(info.getName())) {
                    UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (Exception e) {
            // Handle exceptions related to Look and Feel
            e.printStackTrace();
        }

        // Set the frame properties
        setSize(1280, 720);

        RoomList list = new RoomList();
        String[] columnHead = {"Room ID", "Floor", "Room Number", "Room Type", "Price", "Availability"};

        // Put room data into the table
        TableModel model;
        model = new DefaultTableModel(list.getRoomList(), columnHead);
        JTable table = new JTable(model);
        JScrollPane scrollpane = new JScrollPane(table);
        scrollpane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);

        // Styling for the scrollpane and table
        table.setPreferredScrollableViewportSize(new Dimension(1000, 700));
        scrollpane.setPreferredSize(new Dimension(1000, 700));
        table.setFont(new Font("Open Sans", 0, 16));
        table.setRowHeight(32);
        table.getTableHeader().setOpaque(false);
        table.getTableHeader().setFont(new Font("Open Sans", Font.BOLD, 20));
        table.getTableHeader().setForeground(Color.WHITE);
        table.getTableHeader().setBackground(Color.BLACK);

        tablePanel.add(scrollpane);
        buttons.add(add);
        buttons.add(update);
        buttons.add(delete);
        buttons.add(cancel);
        all.add(tablePanel);
        all.add(buttons);
        add(all);

        add.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                JTextField ID = new JTextField();
                JTextField floorNum = new JTextField();
                JTextField roomNum = new JTextField();
                JComboBox type = new JComboBox();
                JTextField price = new JTextField();
                JComboBox availability = new JComboBox();

                type.addItem("STUDIO SINGLE");
                type.addItem("STUDIO DOUBLE");
                type.addItem("CLASSIC SINGLE");
                type.addItem("CLASSIC DOUBLE");
                type.addItem("STANDARD SINGLE");
                type.addItem("STANDARD DOUBLE");
                availability.addItem("Taken");
                availability.addItem("Available");

                Object[] fields = {"ID: ", ID, "Floor: ", floorNum, "Room: ", roomNum, "Type: ", type, "Price", price, "Availability: ", availability};
                int result = JOptionPane.showConfirmDialog(null, fields, "Input Dialog", JOptionPane.OK_CANCEL_OPTION);

                if (result == JOptionPane.OK_OPTION) {
                    list.addRow(ID.getText(), floorNum.getText(), roomNum.getText(), (String) type.getSelectedItem(), price.getText(), (String) availability.getSelectedItem());
                    DefaultTableModel newModel = new DefaultTableModel(list.getRoomList(), columnHead);
                    table.setModel(newModel);
                    scrollpane.setViewportView(table);
                    invalidate();
                    revalidate();
                    repaint();
                }
            }
        });

        update.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                selectedRow = table.getSelectedRow();
                Object[] rowOnly = new Object[6];
                System.arraycopy(list.getRoomList()[selectedRow], 0, rowOnly, 0, 6);

                JLabel ID = new JLabel((String) rowOnly[0]);
                JLabel floorNum = new JLabel((String) rowOnly[1]);
                JLabel roomNum = new JLabel((String) rowOnly[2]);
                JLabel type = new JLabel((String) rowOnly[3]);
                JLabel price = new JLabel ((String) rowOnly[4]);
                JComboBox availability = new JComboBox();

                availability.addItem("Unavailable");
                availability.addItem("Available");

                Object[] fields = {"ID:\t", ID, "Floor:\t", floorNum, "Room:\t", roomNum, "Type:\t", type, "Price:/t", price, "Availability:\t", availability};
                int result = JOptionPane.showConfirmDialog(null, fields, "Input Dialog", JOptionPane.OK_CANCEL_OPTION);

                if (result == JOptionPane.OK_OPTION) {
                    list.setRoomElement(selectedRow, 5, (String) availability.getSelectedItem());
                    DefaultTableModel newModel = new DefaultTableModel(list.getRoomList(), columnHead);
                    table.setModel(newModel);
                    scrollpane.setViewportView(table);
                    invalidate();
                    revalidate();
                    repaint();
                }
            }
        });

        delete.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                selectedRow = table.getSelectedRow();
                list.deleteRow(selectedRow);
                if (selectedRow != -1) { // check if a row is selected
                    DefaultTableModel model = (DefaultTableModel) table.getModel();
                    model.removeRow(selectedRow);
                }
                invalidate();
                revalidate();
                repaint();
            }
        });

        cancel.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                setVisible(false);
                new AdminHome().setVisible(true);
            }
        });

        // Default frame stuff
        setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE);
        setVisible(true);
    }

    public static void main(String[] args) {
        AdminRooms viewRoom = new AdminRooms();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}
