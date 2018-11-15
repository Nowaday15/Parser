import requests
from qtdes2 import *
import sys
from PyQt5 import *
from bs4 import BeautifulSoup


# получение готовой таблицы track название/исполнитель/дата релиза по ссылке url
def get_tracks_list(url):
    # получение таблицы элементов для обработки
    def get_variable_table(soup_getted):
        table = soup_getted.find('ul', class_='bucket-items ec-bucket')
        rowNames = table.findAll('span', class_='buk-track-primary-title')
        rowNamesMix = table.findAll('span', class_='buk-track-remixed')
        rowArtists = table.findAll('p', class_='buk-track-artists')
        rowDates = table.findAll('p', class_='buk-track-released')
        return rowNames, rowNamesMix, rowArtists, rowDates

    # получение составленной таблицы из сырых данных
    def do_row(rowNames, rowNamesMix, rowArtists, rowDates):
        i = 0
        for rowName in rowNames:
            track[i][0] = rowName.find(text=True)
            i += 1

        i = 0
        for rowNameMix in rowNamesMix:
            track[i][0] += ' ' + rowNameMix.find(text=True)
            i += 1

        i = 0
        for rowArtist in rowArtists:
            track[i][1] = ' '.join(
                [block.string for block in rowArtist.findAll('a')])
            i += 1

        i = 0
        for rowDate in rowDates:
            track[i][2] = rowDate.find(text=True)
            i += 1
        return track

    # сортировка сырой таблицы по released data
    def sortirovka(a):
        return a[2]

    # удаление из таблицы пустых элементов
    def sokratit(track):
        i = 0
        while True:
            line = track[i]
            if len(line[0]) == 0:
                track.pop(i)
                i -= 1
            i += 1
            if i >= len(track):
                break
        return track

    # парсинг url
    r = requests.get(url)

    # soup полученного результата
    soup = BeautifulSoup(r.text, features="html.parser")

    # получение данных для таблицы
    rowNames, rowNamesMix, rowArtists, rowDates = get_variable_table(soup)

    # объявление формата track
    track = [['', '', ''] for i in range(150)]

    # составление сырой таблицы track
    track = do_row(rowNames, rowNamesMix, rowArtists, rowDates)

    # сортировка
    track.sort(reverse=True, key=sortirovka)

    # сокращение
    sokratit(track)

    # готовая таблица track
    return track

#    style =

# вывод готовой таблицы в файл output.txt поменял на dll
def output(track, maxcount):
    outputfile = open('output.dll', 'w', encoding='utf-8')
    i = 0
    for line in track:
        line0 = str(line[0] + '%20')
        line1 = str(line[1])
        s = str(line0 + line1).replace(' ', '%20')
        # line2 = str(line[2] + '\n') добавление даты
        outputfile.write(s + '\n')
        i += 1
        if i == maxcount:
            break
    outputfile.close()
    return

# Если выбрана кнопка "TOP100" получить url з get_url а есди "Tracks" из get_url_fresh

# записали стиль в файл
def output (selectedstyle):
    outputfile = open('style.dll', 'w', encoding='utf-8')
    outputfile.write(selectedstyle)
    outputfile.close()
    return

# выбор url под название трека
def get_url(style_name):
    styles = {
        'All styles': 'https://www.beatport.com/top-100',
        'AFRO HOUSE': 'https://www.beatport.com/genre/afro-house/89/top-100',
        'BIG ROOM': 'https://www.beatport.com/genre/big-room/79/top-100',
        'BREAKS': 'https://www.beatport.com/genre/breaks/9/top-100',
        'DJ TOOLS': 'https://www.beatport.com/genre/dj-tools/16/top-100',
        'DANCE': 'https://www.beatport.com/genre/dance/39/top-100',
        'DEEP HOUSE': 'https://www.beatport.com/genre/deep-house/12/top-100',
        'DRUM & BASS': 'https://www.beatport.com/genre/drum-and-bass/1/top-100',
        'DUBSTEP': 'https://www.beatport.com/genre/dubstep/18/top-100',
        'ELECTRO HOUSE': 'https://www.beatport.com/genre/electro-house/17/top-100',
        'ELECTRONICA / DOWNTEMPO': 'https://www.beatport.com/genre/electronica-downtempo/3/top-100',
        'FUNK / SOUL / DISCO': 'https://www.beatport.com/genre/funk-soul-disco/40/top-100',
        'FUNKY / GROOVE / JACKIN\' HOUSE': 'https://www.beatport.com/genre/funky-groove-jackin-house/81/top-100',
        'FUTURE HOUSE': 'https://www.beatport.com/genre/future-house/65/top-100',
        'GARAGE / BASSLINE / GRIME': 'https://www.beatport.com/genre/garage-bassline-grime/86/top-100',
        'GLITCH HOP': 'https://www.beatport.com/genre/glitch-hop/49/top-100',
        'HARD DANCE': 'https://www.beatport.com/genre/hard-dance/8/top-100',
        'HARDCORE / HARD TECHNO': 'https://www.beatport.com/genre/hardcore-hard-techno/2/top-100',
        'HIP-HOP / R&B': 'https://www.beatport.com/genre/hip-hop-r-and-b/38/top-100',
        'HOUSE': 'https://www.beatport.com/genre/house/5/top-100',
        'INDIE DANCE / NU DISCO': 'https://www.beatport.com/genre/indie-dance-nu-disco/37/top-100',
        'LEFTFIELD BASS': 'https://www.beatport.com/genre/leftfield-bass/85/top-100',
        'LEFTFIELD HOUSE & TECHNO': 'https://www.beatport.com/genre/leftfield-house-and-techno/80/top-100',
        'MELODIC HOUSE & TECHNO': 'https://www.beatport.com/genre/melodic-house-and-techno/90/top-100',
        'MINIMAL / DEEP TECH': 'https://www.beatport.com/genre/minimal-deep-tech/14/top-100',
        'PROGRESSIVE HOUSE': 'https://www.beatport.com/genre/progressive-house/15/top-100',
        'PSY-TRANCE': 'https://www.beatport.com/genre/psy-trance/13/top-100',
        'REGGAE / DANCEHALL / DUB': 'https://www.beatport.com/genre/reggae-dancehall-dub/41/top-100',
        'TECH HOUSE': 'https://www.beatport.com/genre/tech-house/11/top-100',
        'TECHNO': 'https://www.beatport.com/genre/techno/6/top-100',
        'TRANCE': 'https://www.beatport.com/genre/trance/7/top-100',
        'TRAP / FUTURE BASS': 'https://www.beatport.com/genre/trap-future-bass/87/top-100'}
    url = styles[style_name]
    selectedstyle= styles
#    return selectedstyle
    return url

# выбор url под название трека вкладка tracks
def get_url_fresh(style_name_tracks):
    styles = {
        'Fresh tracks': 'https://www.beatport.com/tracks/all',
        'AFRO HOUSE': 'https://www.beatport.com/genre/afro-house/89/tracks',
        'BIG ROOM': 'https://www.beatport.com/genre/big-room/79/tracks',
        'BREAKS': 'https://www.beatport.com/genre/breaks/9/tracks',
        'DJ TOOLS': 'https://www.beatport.com/genre/dj-tools/16/tracks',
        'DANCE': 'https://www.beatport.com/genre/dance/39/tracks',
        'DEEP HOUSE': 'https://www.beatport.com/genre/deep-house/12/tracks',
        'DRUM & BASS': 'https://www.beatport.com/genre/drum-and-bass/1/tracks',
        'DUBSTEP': 'https://www.beatport.com/genre/dubstep/18/tracks',
        'ELECTRO HOUSE': 'https://www.beatport.com/genre/electro-house/17/tracks',
        'ELECTRONICA / DOWNTEMPO': 'https://www.beatport.com/genre/electronica-downtempo/3/tracks',
        'FUNK / SOUL / DISCO': 'https://www.beatport.com/genre/funk-soul-disco/40/tracks',
        'FUNKY / GROOVE / JACKIN\' HOUSE': 'https://www.beatport.com/genre/funky-groove-jackin-house/81/tracks',
        'FUTURE HOUSE': 'https://www.beatport.com/genre/future-house/65/tracks',
        'GARAGE / BASSLINE / GRIME': 'https://www.beatport.com/genre/garage-bassline-grime/86/tracks',
        'GLITCH HOP': 'https://www.beatport.com/genre/glitch-hop/49/tracks',
        'HARD DANCE': 'https://www.beatport.com/genre/hard-dance/8/tracks',
        'HARDCORE / HARD TECHNO': 'https://www.beatport.com/genre/hardcore-hard-techno/2/tracks',
        'HIP-HOP / R&B': 'https://www.beatport.com/genre/hip-hop-r-and-b/38/tracks',
        'HOUSE': 'https://www.beatport.com/genre/house/5/tracks',
        'INDIE DANCE / NU DISCO': 'https://www.beatport.com/genre/indie-dance-nu-disco/37/tracks',
        'LEFTFIELD BASS': 'https://www.beatport.com/genre/leftfield-bass/85/tracks',
        'LEFTFIELD HOUSE & TECHNO': 'https://www.beatport.com/genre/leftfield-house-and-techno/80/tracks',
        'MELODIC HOUSE & TECHNO': 'https://www.beatport.com/genre/melodic-house-and-techno/90/tracks',
        'MINIMAL / DEEP TECH': 'https://www.beatport.com/genre/minimal-deep-tech/14/tracks',
        'PROGRESSIVE HOUSE': 'https://www.beatport.com/genre/progressive-house/15/tracks',
        'PSY-TRANCE': 'https://www.beatport.com/genre/psy-trance/13/tracks',
        'REGGAE / DANCEHALL / DUB': 'https://www.beatport.com/genre/reggae-dancehall-dub/41/tracks',
        'TECH HOUSE': 'https://www.beatport.com/genre/tech-house/11/tracks',
        'TECHNO': 'https://www.beatport.com/genre/techno/6/tracks',
        'TRANCE': 'https://www.beatport.com/genre/trance/7/tracks',
        'TRAP / FUTURE BASS': 'https://www.beatport.com/genre/trap-future-bass/87/tracks'}
    url = styles[style_name_tracks]
    return url

# url страницы, с которой составлять таблицу track
# url = 'https://www.beatport.com/genre/funk-soul-disco/40/top-100'

# создание таблицы track

# url = 'https://www.beatport.com/tracks/all'
# track = get_tracks_list(url)
# output(track)



class MyWin(QtWidgets.QMainWindow):
    def __init__(self, parent=None):
        QtWidgets.QWidget.__init__(self, parent)
        self.ui = Ui_MainWindow()
        self.ui.setupUi(self)
        # Здесь прописываем событие нажатия на кнопку
        # self.ui.comboBox.activated.connect(self.ClickBox)
        self.ui.horizontalSlider.sliderMoved.connect(self.Slider_Value)
        self.ui.pushButton.clicked.connect(self.Button)


#        self.b1 = QRadioButton("TOP100")
#        self.b1.setChecked(True)
#        self.b1.toggled.connect(lambda: self.btnstate(self.b1))

#        self.b2 = QRadioButton("Fresh")
#        self.b2.toggled.connect(lambda: self.btnstate(self.b2))


    # Пока пустая функция которая выполняется
    # при нажатии на кнопку
    def Button(self):
        # style = str(self.ui.comboBox.currentText())
        # track = get_tracks_list(get_url(style))
        # maxtracks = int(str(self.ui.label_counter.text())[53:-25])
        output(get_tracks_list(get_url(str(self.ui.comboBox.currentText()))),
               int(str(self.ui.label_counter.text())[53:-25]))
        self.ui.messageBox.setVisible(True)



    def Slider_Value(self):
        value = int(self.ui.horizontalSlider.value())
        value = str(int(value / 10) * 10 + 10)
        self.ui.label_counter.setText("<html><head/><body><p><span style=\""
                                      " ""font-size:16pt;\">" + value + "</span></p></body></html>")



if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    myapp = MyWin()
    myapp.show()
    sys.exit(app.exec_())
