package javagroup70;

import OOPJ.Classes.Payment;
import OOPJ.Classes.Reservation;
import OOPJ.Classes.User;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.UIManager;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableModel;

/**
 *
 * @author ACER
 */
public class AdminReservations extends JFrame implements ActionListener {

    private JButton accept = new JButton("Accept");
    private JButton decline = new JButton("Decline");
    private JButton remove = new JButton("Remove");
    private JButton cancel = new JButton("Cancel");
    private JPanel buttons = new JPanel();
    private JPanel tablePanel = new JPanel();
    private JPanel all = new JPanel();
    int selectedRow = 0;

    public AdminReservations() {
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

        Reservation list = new Reservation();

        /////////////////Checked til here
        String[] columnHead = {"Reservation ID", "Room ID", "Passport", "Initital Date", "Final Date", "Total Month", "Month Left", "Payment Left", "Price", "Status"};

        // Put room data into the table
        TableModel model;
        model = new DefaultTableModel(list.getReservationList(), columnHead);
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
        buttons.add(accept);
        buttons.add(decline);
        buttons.add(remove);
        buttons.add(cancel);
        all.add(tablePanel);
        all.add(buttons);
        add(all);

        accept.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                selectedRow = table.getSelectedRow();
                Object[] rowOnly = new Object[10];
                System.arraycopy(list.getReservationList()[selectedRow], 0, rowOnly, 0, 10);

                JLabel ID = new JLabel((String) rowOnly[0]);
                JLabel roomID = new JLabel((String) rowOnly[1]);
                JLabel passport = new JLabel((String) rowOnly[2]);
                JLabel initialDate = new JLabel((String) rowOnly[3]);
                JLabel finalDate = new JLabel((String) rowOnly[4]);
                JLabel totalMonth = new JLabel((String) rowOnly[5]);
                JLabel leftMonth = new JLabel((String) rowOnly[6]);
                JLabel paymentLeft = new JLabel((String) rowOnly[7]);
                JLabel price = new JLabel((String) rowOnly[8]);

                Object[] fields = {"ID:\t", ID, "Room ID:\t", roomID, "Passport:\t", passport, "Initial Date:\t", initialDate, "Final Date:\t", finalDate, "Total Month:\t", totalMonth, "Left Month:\t", leftMonth, "Payment Left:\t", paymentLeft, "Price:\t", price};
                int result = JOptionPane.showConfirmDialog(null, fields, "Input Dialog", JOptionPane.OK_CANCEL_OPTION);

                if (result == JOptionPane.OK_OPTION) {
                    list.setReservationElement(selectedRow, 9, "Accepted");
                    Payment payment = new Payment();
                    try {
                        payment.addRow((String) rowOnly[1], (String) rowOnly[2], (String) rowOnly[8]);
                    } catch (IOException ex) {
                        Logger.getLogger(AdminReservations.class.getName()).log(Level.SEVERE, null, ex);
                    }
                    DefaultTableModel newModel = new DefaultTableModel(list.getReservationList(), columnHead);
                    table.setModel(newModel);
                    scrollpane.setViewportView(table);
                    invalidate();
                    revalidate();
                    repaint();
                }
            }
        });

        decline.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                selectedRow = table.getSelectedRow();
                Object[] rowOnly = new Object[10];
                System.arraycopy(list.getReservationList()[selectedRow], 0, rowOnly, 0, 10);

                JLabel ID = new JLabel((String) rowOnly[0]);
                JLabel roomID = new JLabel((String) rowOnly[1]);
                JLabel passport = new JLabel((String) rowOnly[2]);
                JLabel initialDate = new JLabel((String) rowOnly[3]);
                JLabel finalDate = new JLabel((String) rowOnly[4]);
                JLabel totalMonth = new JLabel((String) rowOnly[5]);
                JLabel leftMonth = new JLabel((String) rowOnly[6]);
                JLabel paymentLeft = new JLabel((String) rowOnly[7]);
                JLabel price = new JLabel((String) rowOnly[8]);

                Object[] fields = {"ID:\t", ID, "Room ID:\t", roomID, "Passport:\t", passport, "Initial Date:\t", initialDate, "Final Date:\t", finalDate, "Total Month:\t", totalMonth, "Left Month:\t", leftMonth, "Payment Left:\t", paymentLeft, "Price:\t", price};
                int result = JOptionPane.showConfirmDialog(null, fields, "Input Dialog", JOptionPane.OK_CANCEL_OPTION);

                if (result == JOptionPane.OK_OPTION) {
                    list.setReservationElement(selectedRow, 9, "Declined");
                    DefaultTableModel newModel = new DefaultTableModel(list.getReservationList(), columnHead);
                    table.setModel(newModel);
                    scrollpane.setViewportView(table);
                    invalidate();
                    revalidate();
                    repaint();
                }
            }
        });

        remove.addActionListener(new ActionListener() {
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
        AdminReservations viewReservation = new AdminReservations();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}
