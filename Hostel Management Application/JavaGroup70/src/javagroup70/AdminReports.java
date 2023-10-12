package javagroup70;

import OOPJ.Classes.Logs;
import OOPJ.Classes.Payment;
import OOPJ.Classes.RoomList;
import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.ParseException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

public class AdminReports extends JFrame implements ActionListener {

    // Elements that will stay put
    private JComboBox<String> reportTypeComboBox;
    private JComboBox<String> monthComboBox;
    private JComboBox<String> yearComboBox;
    private JButton cancelButton;

    // Elements for different selections
    private JPanel mainPanel;
    private JPanel reportPanel;
    private DefaultTableModel roomReportTableModel;
    private JTable roomReportTable;
    private JComboBox<String> roomStatusComboBox;
    private DefaultTableModel incomeReportTableModel;
    private JTable incomeReportTable;
    private JLabel incomeTotalLabel;
    private DefaultTableModel loginReportTableModel;
    private JTable loginReportTable;
    private JLabel loginTotalLabel;
    JScrollPane incomeReportScrollPane = new JScrollPane();
    JScrollPane loginReportScrollPane = new JScrollPane();
    JScrollPane roomReportScrollPane = new JScrollPane();

    public AdminReports() throws ParseException {
        super("View Reports");

        // set up the main panel
        mainPanel = new JPanel();
        mainPanel.setLayout(new BorderLayout());

        // set up the report type combo box
        String[] reportTypes = {"Room report", "Income report", "Login report"};
        reportTypeComboBox = new JComboBox<String>(reportTypes);
        reportTypeComboBox.addActionListener(this);

        // set up the month combo box
        String[] months = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
        monthComboBox = new JComboBox<String>(months);
        monthComboBox.addActionListener(this);

        // set up the year combo box
        String[] years = {"2022", "2023"};
        yearComboBox = new JComboBox<String>(years);
        yearComboBox.addActionListener(this);

        // set up the cancel button
        cancelButton = new JButton("Cancel");
        cancelButton.addActionListener(this);

        // set up the report panel
        reportPanel = new JPanel();
        reportPanel.setLayout(new BoxLayout(reportPanel, BoxLayout.Y_AXIS));

        // set up the room report table model and table
        roomReportTableModel = new DefaultTableModel(new String[]{"Room Number", "Floor", "Room Type", "Status"}, 0);
        roomReportTable = new JTable(roomReportTableModel);
        roomReportScrollPane.setViewportView(roomReportTable);

        // set up the room status combo box
        String[] roomStatuses = {"Available", "Unavailable"};
        roomStatusComboBox = new JComboBox<String>(roomStatuses);
        roomStatusComboBox.addActionListener(this);

        // set up the income report table model and table
        incomeReportTableModel = new DefaultTableModel(new String[]{"Payment ID", "Passport", "Date", "Amount"}, 0);
        incomeReportTable = new JTable(incomeReportTableModel);
        incomeReportScrollPane.setViewportView(incomeReportTable);

        // set up the income total label
        incomeTotalLabel = new JLabel("Total: $0.00");

        // set up the login report table model and table
        loginReportTableModel = new DefaultTableModel(new String[]{"Passport", "Date", "Time"}, 0);
        loginReportTable = new JTable(loginReportTableModel);
        loginReportScrollPane.setViewportView(loginReportTable);

        // set up the login total label
        loginTotalLabel = new JLabel("Total logins: 0");

        // create a panel to hold the combo boxes
        JPanel comboPanel = new JPanel();
        comboPanel.setLayout(new BoxLayout(comboPanel, BoxLayout.X_AXIS));

        // add the combo boxes to the panel
        comboPanel.add(reportTypeComboBox);
        comboPanel.add(Box.createRigidArea(new Dimension(5, 0))); // add some spacing between the combo boxes
        comboPanel.add(monthComboBox);
        comboPanel.add(Box.createRigidArea(new Dimension(5, 0))); // add some spacing between the combo boxes
        comboPanel.add(yearComboBox);

        // add the combo box panel and cancel button to the main panel
        mainPanel.add(comboPanel, BorderLayout.NORTH);
        mainPanel.add(cancelButton, BorderLayout.SOUTH);

        // add the report panel to the main panel
        mainPanel.add(reportPanel, BorderLayout.CENTER);

        // set the default report to the room report
        showRoomReport();

        // add the main panel to the frame
        add(mainPanel);

        // set the size and visibility of the frame
        setSize(800, 600);
        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == reportTypeComboBox) {
            // show the corresponding report based on the selected report type
            switch (reportTypeComboBox.getSelectedIndex()) {
                case 0:
                    try {
                    showRoomReport();
                } catch (ParseException ex) {
                    Logger.getLogger(AdminReports.class.getName()).log(Level.SEVERE, null, ex);
                }
                break;
                case 1:
                    try {
                    showIncomeReport();
                } catch (ParseException ex) {
                    Logger.getLogger(AdminReports.class.getName()).log(Level.SEVERE, null, ex);
                }
                break;
                case 2:
                    try {
                    showLoginReport();
                } catch (ParseException ex) {
                    Logger.getLogger(AdminReports.class.getName()).log(Level.SEVERE, null, ex);
                }
                break;
            }
        } else if (e.getSource() == yearComboBox || e.getSource() == monthComboBox) {
            // show the corresponding report based on the selected report type, year, andmonth
            switch (reportTypeComboBox.getSelectedIndex()) {
                case 0:
                    try {
                    showRoomReport();
                } catch (ParseException ex) {
                    Logger.getLogger(AdminReports.class.getName()).log(Level.SEVERE, null, ex);
                }
                break;
                case 1:
                    try {
                    showIncomeReport();
                } catch (ParseException ex) {
                    Logger.getLogger(AdminReports.class.getName()).log(Level.SEVERE, null, ex);
                }
                break;
                case 2:
                    try {
                    showLoginReport();
                } catch (ParseException ex) {
                    Logger.getLogger(AdminReports.class.getName()).log(Level.SEVERE, null, ex);
                }
                break;
            }
        } else if (e.getSource() == roomStatusComboBox) {
            // show the room report with the selected room status
            try {
                showRoomReport();
            } catch (ParseException ex) {
                Logger.getLogger(AdminReports.class.getName()).log(Level.SEVERE, null, ex);
            }
        } else if (e.getSource() == cancelButton) {
            setVisible(false);
            new AdminHome().setVisible(true);
        }
    }

    private void showRoomReport() throws ParseException {
        // show the room report table
        reportPanel.removeAll();

        // get the existing table model from the JTable
        DefaultTableModel tableModel = (DefaultTableModel) roomReportTable.getModel();
        RoomList rooms = new RoomList();

        // call the makeReport method to get the filtered log entries
        Object[][] roomsFiltered = rooms.makeReport(((String) roomStatusComboBox.getSelectedItem()));

        // clear the existing rows from the table model
        tableModel.setRowCount(0);

        // add the filtered log entries to the table model
        for (Object[] row : roomsFiltered) {
            tableModel.addRow(row);
        }

        reportPanel.add(roomStatusComboBox, BorderLayout.NORTH);
        reportPanel.add(roomReportScrollPane, BorderLayout.CENTER);
        reportPanel.revalidate();
        reportPanel.repaint();
    }

    private void showIncomeReport() throws ParseException {
        // show the income report table
        reportPanel.removeAll();

        // get the existing table model from the JTable
        DefaultTableModel tableModel = (DefaultTableModel) incomeReportTable.getModel();
        Payment payment = new Payment();

        // call the makeReport method to get the filtered log entries
        Object[][] paymentFiltered = payment.makeReport((String) monthComboBox.getSelectedItem(), (String) yearComboBox.getSelectedItem());
        // clear the existing rows from the table model
        tableModel.setRowCount(0);

        // add the filtered log entries to the table model
        for (Object[] row : paymentFiltered) {
            tableModel.addRow(row);
        }

        // Initialize total value to 0
        int total = 0;

        // Iterate over rows in the table model and add 4th column values to total
        for (int i = 0; i < tableModel.getRowCount(); i++) {
            if ((String) tableModel.getValueAt(i, 3) != null) {
                total += Integer.parseInt((String) tableModel.getValueAt(i, 3));
            }
        }

        incomeTotalLabel.setText("Total: $" + String.valueOf(total) + ".00");

        reportPanel.add(incomeReportScrollPane, BorderLayout.CENTER);
        reportPanel.add(incomeTotalLabel, BorderLayout.SOUTH);
        reportPanel.revalidate();
        reportPanel.repaint();
    }

    private void showLoginReport() throws ParseException {
        // show the login report table
        reportPanel.removeAll();

        // create a new JScrollPane and add the login report table to it
        JScrollPane loginReportScrollPane = new JScrollPane(loginReportTable);
        loginReportScrollPane.setPreferredSize(new Dimension(600, 400));

        // get the existing table model from the JTable
        DefaultTableModel tableModel = (DefaultTableModel) loginReportTable.getModel();
        Logs log = new Logs();

        // call the makeReport method to get the filtered log entries
        Object[][] logsFiltered = log.makeReport((String) monthComboBox.getSelectedItem(), (String) yearComboBox.getSelectedItem());

        // clear the existing rows from the table model
        tableModel.setRowCount(0);

        // add the filtered log entries to the table model
        for (Object[] row : logsFiltered) {
            tableModel.addRow(row);
        }

        // Initialize total value to 0
        int total = 0;

        // Iterate over rows in the table model and add 4th column values to total
        for (int i = 0; i < tableModel.getRowCount(); i++) {
            if ((String) tableModel.getValueAt(i, 0) != null) {
                total += 1;
            }
        }

        // set label to correct number of rows
        loginTotalLabel.setText("Total logins: " + total);

        // add the login report table and total label to the login report panel
        JPanel loginReportPanel = new JPanel(new BorderLayout());
        loginReportPanel.add(loginReportScrollPane, BorderLayout.CENTER);
        loginReportPanel.add(loginTotalLabel, BorderLayout.SOUTH);

        reportPanel.add(loginReportPanel, BorderLayout.CENTER);
        reportPanel.revalidate();
        reportPanel.repaint();
    }

    public static void main(String[] args) throws ParseException {
        // create and show the view reports frame
        new AdminReports();
    }
}
