/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javagroup70;

import OOPJ.Classes.UserList;
import OOPJ.Classes.User;
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

/**
 *
 * @author ACER
 */
public class AdminUsers extends JFrame implements ActionListener {

    private JButton addNew = new JButton("Add new");
    private JButton edit = new JButton("Edit");
    private JButton remove = new JButton("Remove");
    private JButton cancel = new JButton("Cancel");
    private JPanel buttons = new JPanel();
    private JPanel tablePanel = new JPanel();
    private JPanel all = new JPanel();
    int selectedRow = 0;

    public AdminUsers() {
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

        UserList list = new UserList();

        // Make an array of heading names
        String[] columnHead = {"Passport", "Role", "First Name", "Last Name", "Age", "Gender", "Username", "Password", "Contact"};

        // Put room data into the table
        TableModel model;
        model = new DefaultTableModel(list.getStudentList(), columnHead);
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
        buttons.add(addNew);
        buttons.add(edit);
        buttons.add(remove);
        buttons.add(cancel);
        all.add(tablePanel);
        all.add(buttons);
        add(all);

        addNew.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                JTextField passport = new JTextField();
                JComboBox role = new JComboBox();
                JTextField firstName = new JTextField();
                JTextField lastName = new JTextField();
                
                JComboBox gender = new JComboBox();
                JTextField username = new JTextField();
                JTextField password = new JTextField();
                JTextField contact = new JTextField();

                gender.addItem("Male");
                gender.addItem("Female");
                role.addItem("Admin");
                role.addItem("Student");

                Integer[] ages = new Integer[59];
                for (int i = 0; i < 59; i++) {
                    ages[i] = i + 12;
                }
                JComboBox<Integer> age = new JComboBox<>(ages);
                Object[] fields = {"Passport: ", passport, "Role: ", role, "First Name: ", firstName, "Last Name: ", lastName, "Age: ", age, "Gender: ", gender, "Username: ", username, "Password: ", password, "Contact: ", contact};
                int result = JOptionPane.showConfirmDialog(null, fields, "Input Dialog", JOptionPane.OK_CANCEL_OPTION);

                if (result == JOptionPane.OK_OPTION) {
                    list.addRow(passport.getText(), (String) role.getSelectedItem(), firstName.getText(), lastName.getText(), String.valueOf(age.getSelectedItem()), (String) gender.getSelectedItem(), username.getText(), password.getText(), contact.getText());
                    DefaultTableModel newModel = new DefaultTableModel(list.getStudentList(), columnHead);
                    table.setModel(newModel);
                    scrollpane.setViewportView(table);
                    invalidate();
                    revalidate();
                    repaint();
                }
            }
        });

        edit.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                selectedRow = table.getSelectedRow();
                Object[] rowOnly = new Object[9];
                System.arraycopy(list.getStudentList()[selectedRow], 0, rowOnly, 0, 9);

                JLabel passport = new JLabel((String) rowOnly[0]);
                JComboBox role = new JComboBox();
                JTextField firstName = new JTextField((String) rowOnly[2]);
                JTextField lastName = new JTextField((String) rowOnly[3]);
                JComboBox gender = new JComboBox();
                JTextField username = new JTextField((String) rowOnly[6]);
                JTextField password = new JTextField((String) rowOnly[7]);
                JTextField contact = new JTextField((String) rowOnly[8]);

                gender.addItem("Male");
                gender.addItem("Female");
                role.addItem("Admin");
                role.addItem("Student");

                Integer[] ages = new Integer[59];
                for (int i = 0; i < 59; i++) {
                    ages[i] = i + 12;
                }
                JComboBox<Integer> age = new JComboBox<>(ages);

                Object[] fields = {"Your passport:\t", passport, "Role: \t", role, "First Name:\t", firstName, "Last Name:\t", lastName, "Age:\t", age, "Gender:\t", gender, "Username:\t", username, "Password:\t", password, "Contact:\t", contact};
                int result = JOptionPane.showConfirmDialog(null, fields, "Input Dialog", JOptionPane.OK_CANCEL_OPTION);

                if (result == JOptionPane.OK_OPTION) {
                    if (User.getPassport() == passport.getText()){
                        User.setFirstName(firstName.getText());
                        User.setLastName(lastName.getText());
                        User.setUsername(username.getText());
                        User.setPassword(password.getText());
                        User.setRole((String) role.getSelectedItem());
                    }
                    list.setStudentElement(selectedRow, 1, (String) role.getSelectedItem());
                    list.setStudentElement(selectedRow, 2, firstName.getText());
                    list.setStudentElement(selectedRow, 3, lastName.getText());
                    list.setStudentElement(selectedRow, 4, String.valueOf(age.getSelectedItem()));
                    list.setStudentElement(selectedRow, 5, (String) gender.getSelectedItem());
                    list.setStudentElement(selectedRow, 6, username.getText());
                    list.setStudentElement(selectedRow, 7, password.getText());
                    list.setStudentElement(selectedRow, 8, contact.getText());
                    
                    
                    DefaultTableModel newModel = new DefaultTableModel(list.getStudentList(), columnHead);
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
        AdminUsers viewStudents = new AdminUsers();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}
