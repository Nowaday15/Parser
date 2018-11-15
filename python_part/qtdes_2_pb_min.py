from PyQt5 import QtCore, QtGui, QtWidgets

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(300, 350)


        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")

        self.pushButton = QtWidgets.QPushButton(self.centralwidget)
        self.pushButton.setGeometry(QtCore.QRect(35, 270, 230, 30))
        self.pushButton.setObjectName("pushButton")

        self.label = QtWidgets.QLabel(self.centralwidget)
        self.label.setGeometry(QtCore.QRect(30, 10, 230, 40))
        self.label.setObjectName("label")

        self.progressbar = QtWidgets.QProgressBar(self.centralwidget)
        self.progressbar.setGeometry(QtCore.QRect(35, 240, 230, 20))
        self.progressbar.setVisible(False)
        self.progressbar.setObjectName("progressbar")
        self.progressbar.setTextVisible(False)

        self.messageBox = QtWidgets.QMessageBox()
        self.messageBox.setInformativeText('Done!')
        self.messageBox.setWindowTitle("Status")
        self.messageBox.setVisible(False)
        self.messageBox.setObjectName("messageBox")

        self.comboBox = QtWidgets.QComboBox(self.centralwidget)
        self.comboBox.setGeometry(QtCore.QRect(35, 100, 230, 20))
        self.comboBox.setObjectName("comboBox")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")
        self.comboBox.addItem("")

        self.horizontalSlider = QtWidgets.QSlider(self.centralwidget)
        self.horizontalSlider.setGeometry(QtCore.QRect(35, 200, 180, 20))
        self.horizontalSlider.setMinimum(10)
        self.horizontalSlider.setMaximum(110)
        self.horizontalSlider.setSingleStep(10)
        self.horizontalSlider.setProperty("value", 10)
        self.horizontalSlider.setOrientation(QtCore.Qt.Horizontal)
        self.horizontalSlider.setObjectName("horizontalSlider")

        self.label_counter = QtWidgets.QLabel(self.centralwidget)
        self.label_counter.setGeometry(QtCore.QRect(230, 195, 40, 30))
        self.label_counter.setObjectName("label_counter")

        self.label_2 = QtWidgets.QLabel(self.centralwidget)
        self.label_2.setGeometry(QtCore.QRect(35, 140, 230, 40))
        self.label_2.setObjectName("label_2")

        self.radioButton = QtWidgets.QRadioButton(self.centralwidget)
        self.radioButton.setGeometry(QtCore.QRect(60, 60, 61, 20))

        font = QtGui.QFont()
        font.setPointSize(10)
        self.radioButton.setFont(font)
        self.radioButton.setChecked(True)
        self.radioButton.setObjectName("radioButton")

        self.radioButton_2 = QtWidgets.QRadioButton(self.centralwidget)
        self.radioButton_2.setGeometry(QtCore.QRect(165, 60, 72, 20))

        font = QtGui.QFont()
        font.setPointSize(10)
        self.radioButton_2.setFont(font)
        self.radioButton_2.setObjectName("radioButton_2")

        MainWindow.setCentralWidget(self.centralwidget)

        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 300, 21))
        self.menubar.setObjectName("menubar")
        self.menuBP_parser = QtWidgets.QMenu(self.menubar)
        self.menuBP_parser.setObjectName("menuBP_parser")
        MainWindow.setMenuBar(self.menubar)

        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.menubar.addAction(self.menuBP_parser.menuAction())

        self.retranslateUi(MainWindow)


    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle("Parser")
        self.pushButton.setText(_translate("MainWindow", "PARSE IT"))
        self.label.setText(_translate("MainWindow", "<html><head/><body><p align=\"center\"><span style=\" font-size:14pt;\">Выберите жанр</span></p></body></html>"))
        self.comboBox.setItemText(0, _translate("MainWindow", "All styles"))
        self.comboBox.setItemText(1, _translate("MainWindow", "AFRO HOUSE"))
        self.comboBox.setItemText(2, _translate("MainWindow", "BIG ROOM"))
        self.comboBox.setItemText(3, _translate("MainWindow", "BREAKS"))
        self.comboBox.setItemText(4, _translate("MainWindow", "DJ TOOLS"))
        self.comboBox.setItemText(5, _translate("MainWindow", "DANCE"))
        self.comboBox.setItemText(6, _translate("MainWindow", "DEEP HOUSE"))
        self.comboBox.setItemText(7, _translate("MainWindow", "DRUM & BASS"))
        self.comboBox.setItemText(8, _translate("MainWindow", "DUBSTEP"))
        self.comboBox.setItemText(9, _translate("MainWindow", "ELECTRO HOUSE"))
        self.comboBox.setItemText(10, _translate("MainWindow", "ELECTRONICA / DOWNTEMPO"))
        self.comboBox.setItemText(11, _translate("MainWindow", "FUNK / SOUL / DISCO"))
        self.comboBox.setItemText(12, _translate("MainWindow", "FUNKY / GROOVE / JACKIN' HOUSE"))
        self.comboBox.setItemText(13, _translate("MainWindow", "FUTURE HOUSE"))
        self.comboBox.setItemText(14, _translate("MainWindow", "GARAGE / BASSLINE / GRIME"))
        self.comboBox.setItemText(15, _translate("MainWindow", "GLITCH HOP"))
        self.comboBox.setItemText(16, _translate("MainWindow", "HARD DANCE"))
        self.comboBox.setItemText(17, _translate("MainWindow", "HARDCORE / HARD TECHNO"))
        self.comboBox.setItemText(18, _translate("MainWindow", "HIP-HOP / R&B"))
        self.comboBox.setItemText(19, _translate("MainWindow", "HOUSE"))
        self.comboBox.setItemText(20, _translate("MainWindow", "INDIE DANCE / NU DISCO"))
        self.comboBox.setItemText(21, _translate("MainWindow", "LEFTFIELD BASS"))
        self.comboBox.setItemText(22, _translate("MainWindow", "LEFTFIELD HOUSE & TECHNO"))
        self.comboBox.setItemText(23, _translate("MainWindow", "MELODIC HOUSE & TECHNO"))
        self.comboBox.setItemText(24, _translate("MainWindow", "MINIMAL / DEEP TECH"))
        self.comboBox.setItemText(25, _translate("MainWindow", "PROGRESSIVE HOUSE"))
        self.comboBox.setItemText(26, _translate("MainWindow", "PSY-TRANCE"))
        self.comboBox.setItemText(27, _translate("MainWindow", "REGGAE / DANCEHALL / DUB"))
        self.comboBox.setItemText(28, _translate("MainWindow", "TECH HOUSE"))
        self.comboBox.setItemText(29, _translate("MainWindow", "TECHNO"))
        self.comboBox.setItemText(30, _translate("MainWindow", "TRANCE"))
        self.comboBox.setItemText(31, _translate("MainWindow", "TRAP / FUTURE BASS"))
        self.label_counter.setText(_translate("MainWindow", "<html><head/><body><p><span style=\" font-size:16pt;\">10</span></p></body></html>"))
        self.label_2.setText(_translate("MainWindow", "<html><head/><body><p align=\"center\"><span style=\" font-size:14pt;\">Количество треков</span></p></body></html>"))
        self.radioButton.setText(_translate("MainWindow", "Tracks"))
        self.radioButton_2.setText(_translate("MainWindow", "TOP 100"))

