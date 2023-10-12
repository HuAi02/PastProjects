package javagroup70;

import OOPJ.Classes.Logs;
import OOPJ.Classes.User;
import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;
import javax.swing.UIManager.*;

public class Login extends JFrame implements ActionListener {
    
    private boolean success = false;

    public Login() {
        // Set Nimbus Look and Feel
        try {
            for (LookAndFeelInfo info : UIManager.getInstalledLookAndFeels()) {
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

        // Create the left and right panels
        JPanel leftPanel = new JPanel();
        leftPanel.setPreferredSize(new Dimension(768, 720));
        leftPanel.setBackground(Color.WHITE);

        // Create a box layout for the left panel
        BoxLayout leftBoxLayout = new BoxLayout(leftPanel, BoxLayout.Y_AXIS);
        leftPanel.setLayout(leftBoxLayout);

        ImageIcon imageIcon = new ImageIcon(getClass().getResource("/icon.png"));
        Image image = imageIcon.getImage();
        Image scaledImage = image.getScaledInstance(500, 500, Image.SCALE_SMOOTH);
        ImageIcon imageIcon2 = new ImageIcon(scaledImage);
        JLabel imageLabel = new JLabel(imageIcon2);
        
        Box box = Box.createVerticalBox();
        box.add(Box.createVerticalGlue());
        box.add(imageLabel);
        box.add(Box.createVerticalGlue());

        leftPanel.add(box);

        JPanel rightPanel = new JPanel(new BorderLayout());
        rightPanel.setPreferredSize(new Dimension(512, 720));
        rightPanel.setBackground(Color.WHITE);

        // Add the login screen components to the right panel
        JPanel loginPanel = new JPanel(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.gridy = 0;
        gbc.gridwidth = 2;
        gbc.insets = new Insets(20, 20, 20, 20);
        JLabel lblTitle = new JLabel("Welcome to Hostel Academic");
        lblTitle.setFont(new Font("Open Sans", Font.PLAIN, 24));
        loginPanel.add(lblTitle, gbc);
        gbc.gridwidth = 1;
        gbc.gridy = 1;
        gbc.gridx = 0;
        JLabel lblUsername = new JLabel("Username:");
        lblUsername.setFont(new Font("Open Sans", Font.PLAIN, 16));
        loginPanel.add(lblUsername, gbc);
        gbc.gridx = 1;
        JTextField txtUsername = new JTextField(16);
        txtUsername.setFont(new Font("Tahoma", Font.PLAIN, 16));
        loginPanel.add(txtUsername, gbc);
        gbc.gridx = 0;
        gbc.gridy = 2;
        JLabel lblPassword = new JLabel("Password:");
        lblPassword.setFont(new Font("Open Sans", Font.PLAIN, 16));
        loginPanel.add(lblPassword, gbc);
        gbc.gridx = 1;
        JPasswordField passfieldPassword = new JPasswordField(16);
        passfieldPassword.setFont(new Font("Tahoma", Font.PLAIN, 16));
        loginPanel.add(passfieldPassword, gbc);
        gbc.gridx = 0;
        gbc.gridy = 3;
        gbc.gridwidth = 2;
        gbc.anchor = GridBagConstraints.CENTER;
        JButton btnLogin = new JButton("Login");
        
        btnLogin.setFont(new Font("Open Sans", Font.PLAIN, 16));
        loginPanel.add(btnLogin, gbc);
        
        //Adding action listener for login button
        btnLogin.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                String username = txtUsername.getText();
                String password = new String(passfieldPassword.getPassword());

                // Text file checking
                File uNamePass = new File("user.txt");
                Scanner scanner = null;
                try {
                    scanner = new Scanner(uNamePass);
                } catch (FileNotFoundException ex) {
                    Logger.getLogger(Login.class.getName()).log(Level.SEVERE, null, ex);
                }
                scanner.useDelimiter(",");
                while (scanner.hasNextLine() && !success) {
                    String line = scanner.nextLine();
                    String[] parts = line.split(",");
                    if (username.equals(parts[6]) && password.equals(parts[7])) {
                        String message = "Welcome back, " + username + "!";
                        JOptionPane.showMessageDialog(null, message, "Login successful", JOptionPane.INFORMATION_MESSAGE);
                        
                        // Update login log
                        Logs entry = new Logs();
                        entry.addRow(parts[0]);
                        
                        success = true;
                        //Clear the textfields
                        txtUsername.setText("");
                        passfieldPassword.setText("");
                        
                        User.setPassport(parts[0]);
                        User.setRole(parts[1]);
                        User.setFirstName(parts[2]);
                        User.setLastName(parts[3]);
                        User.setAge(parts[4]);
                        User.setGender(parts[5]);
                        User.setUsername(parts[6]);
                        User.setPassword(parts[7]);
                        User.setContact(parts[8]);
                        
                        // Check the role of the user
                        switch (User.getRole()){
                            case "Admin":
                                AdminHome n = new AdminHome();
                                setVisible(false);
                                n.setVisible(true);
                                break;
                            case "Student":
                                StudentHome m = new StudentHome();
                                setVisible(false);
                                m.setVisible(true);
                                break;
                        };
                    }
                }
                if (!success) {
                    String message = "Inconrrect credentials, please try again";
                    JOptionPane.showMessageDialog(null, message, "Login failed", JOptionPane.INFORMATION_MESSAGE);
                }
                scanner.close();
                    }
                });

                rightPanel.add(loginPanel, BorderLayout.CENTER);

                // Add the left and right panels to a split pane
                JSplitPane splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, leftPanel, rightPanel);
                splitPane.setDividerLocation(0.6);

                // Add the split pane to the center of the main frame
                getContentPane().add(splitPane, BorderLayout.CENTER);

                setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                setVisible(true);
            }

    public static void main(String[] args) {
        Login loginScreen = new Login();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}