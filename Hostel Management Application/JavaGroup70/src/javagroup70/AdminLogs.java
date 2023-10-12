/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javagroup70;

import OOPJ.Classes.Logs;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
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
public class AdminLogs extends JFrame implements ActionListener{
    private JButton remove = new JButton("Remove");
    private JButton cancel = new JButton("Cancel");
    private JPanel buttons = new JPanel();
    private JPanel tablePanel = new JPanel();
    private JPanel all = new JPanel();
    int selectedRow = 0;

    public AdminLogs() {
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

        Logs list = new Logs();

        // Make an array of heading names
        String[] columnHead = {"Passport", "Date", "Time"};

        // Put room data into the table
        TableModel model;
        model = new DefaultTableModel(list.getLogList(), columnHead);
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
        buttons.add(remove);
        buttons.add(cancel);
        all.add(tablePanel);
        all.add(buttons);
        add(all);

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
        AdminLogs viewLogs = new AdminLogs();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}
