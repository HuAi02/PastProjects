package javagroup70;

import OOPJ.Classes.User;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.ParseException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.UIManager;

public class AdminHome extends JFrame implements ActionListener {

    public AdminHome() {
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

        // Set the window size and position
        setSize(1280, 720);
        setLocationRelativeTo(null);
        setBackground(Color.WHITE);

        // Add buttons and stuff
        JButton btnApplications = new JButton("Reservations");
        JButton btnLogs = new JButton("Logs");
        JButton btnReports = new JButton("Reports");
        JButton btnRooms = new JButton("Rooms");
        JButton btnUsers = new JButton("Users");
        JButton expandAccount = new JButton("Profile");
        JPanel contentPanel = new JPanel();
        JPanel optionsPanel = new JPanel();
        JLabel welcomeMsg = new JLabel("Welcome back, "+User.getFirstName()+" "+User.getLastName());

        add(optionsPanel);
        optionsPanel.add(welcomeMsg);
        optionsPanel.add(expandAccount);
        optionsPanel.add(btnApplications);
        optionsPanel.add(btnUsers);
        optionsPanel.add(btnRooms);
        optionsPanel.add(btnReports);
        optionsPanel.add(btnLogs);

        // All the action listeners and actions
        expandAccount.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                AccountOptions popup = new AccountOptions();
                popup.setLocationRelativeTo(expandAccount);
                popup.setVisible(true);
            }
        });
        btnApplications.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                setVisible(false);
                AdminReservations reservations = new AdminReservations();
                reservations.setVisible(true);
            }
        });
        btnLogs.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                setVisible(false);
                AdminLogs logs = new AdminLogs();
                logs.setVisible(true);
            }
        });
        btnReports.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                setVisible(false);
                AdminReports report;
                try {
                    report = new AdminReports();
                    report.setVisible(true);
                } catch (ParseException ex) {
                    Logger.getLogger(AdminHome.class.getName()).log(Level.SEVERE, null, ex);
                }
                
            }
        });
        btnRooms.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                setVisible(false);
                AdminRooms roomPanel = new AdminRooms();
                roomPanel.setVisible(true);
            }
        });
        btnUsers.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                setVisible(false);
                AdminUsers students = new AdminUsers();
                students.setVisible(true);
            }
        });
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        setVisible(true);
    }

    public static void main(String[] args) {
        AdminHome aHomepage = new AdminHome();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
