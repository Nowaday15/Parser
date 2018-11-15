import requests
from bs4 import BeautifulSoup



# получение готовой таблицы название/исполнитель/дата релиза по ссылке url
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


# вывод готовой таблицы в файл output.txt
def output():
    outputfile = open(
        'output.txt', 'w', encoding='utf-8')
    for line in track:
        line0 = str(line[2] + ' ')
        line1 = str(line[0] + ' ')
        line2 = str(line[1] + '\n')
        outputfile.write(line0 + line1 + line2)
    outputfile.close()
    return


# url страницы, с которой составлять таблицу track
url = 'https://www.beatport.com/genre/funk-soul-disco/40/top-100'

# создание таблицы track
track = get_tracks_list(url)

output()
