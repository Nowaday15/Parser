from __future__ import absolute_import
import requests

from bs4 import BeautifulSoup

from io import open




def get_url(stylename, type):

    if type == u'top100':

        url = unicode(unicode(styles[stylename])+unicode(u'top-100/'))

    if type == u'fresh':

        url = unicode(unicode(styles[stylename])+unicode(u'tracks/'))

        if stylename == u'All styles':

            url = unicode(unicode(url) + u'all/')

    return url


def get_tracks_list(url):


    def get_variable_table(soup_getted):

        table = soup_getted.find(u'ul', class_=u'bucket-items ec-bucket')

        rowNames = table.findAll(u'span', class_=u'buk-track-primary-title')

        rowNamesMix = table.findAll(u'span', class_=u'buk-track-remixed')

        rowArtists = table.findAll(u'p', class_=u'buk-track-artists')

        rowDates = table.findAll(u'p', class_=u'buk-track-released')

        return rowNames, rowNamesMix, rowArtists, rowDates



    def do_row(rowNames, rowNamesMix, rowArtists, rowDates):

        i = 0

        for rowName in rowNames:

            track[i][0] = rowName.find(text=True)

            i += 1



        i = 0

        for rowNameMix in rowNamesMix:

            track[i][0] += u' ' + rowNameMix.find(text=True)

            i += 1



        i = 0

        for rowArtist in rowArtists:

            track[i][1] = u' '.join(

                [block.string for block in rowArtist.findAll(u'a')])

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

    soup = BeautifulSoup(r.text, features=u"html.parser")



    # получение данных для таблицы

    rowNames, rowNamesMix, rowArtists, rowDates = get_variable_table(soup)



    # объявление формата track

    track = [[u'', u'', u''] for i in xrange(150)]



    # составление сырой таблицы track

    track = do_row(rowNames, rowNamesMix, rowArtists, rowDates)



    # сортировка

    track.sort(reverse=True, key=sortirovka)



    # сокращение

    sokratit(track)



    # готовая таблица track

    return track





def output_tracks(track, maxcount):

    outputfile = open(u'todo.dll', u'w', encoding=u'utf-8')

    i = 0

    for line in track:

        line0 = unicode(line[0] + u'%20')

        line1 = unicode(line[1])

        s = unicode(line0 + line1).replace(u' ', u'%20')

        # line2 = str(line[2] + '\n') добавление даты

        outputfile.write(s + u'\n')

        i += 1

        if i == maxcount:

            break

    outputfile.close()

    return





styles = {

        u'All styles': u'https://www.beatport.com/',

        u'AFRO HOUSE': u'https://www.beatport.com/genre/afro-house/89/',

        u'BIG ROOM': u'https://www.beatport.com/genre/big-room/79/',

        u'BREAKS': u'https://www.beatport.com/genre/breaks/9/',

        u'DJ TOOLS': u'https://www.beatport.com/genre/dj-tools/16/',

        u'DANCE': u'https://www.beatport.com/genre/dance/39/',

        u'DEEP HOUSE': u'https://www.beatport.com/genre/deep-house/12/',

        u'DRUM & BASS': u'https://www.beatport.com/genre/drum-and-bass/1/',

        u'DUBSTEP': u'https://www.beatport.com/genre/dubstep/18/',

        u'ELECTRO HOUSE': u'https://www.beatport.com/genre/electro-house/17/',

        u'ELECTRONICA / DOWNTEMPO': u'https://www.beatport.com/genre/electronica-downtempo/3/',

        u'FUNK / SOUL / DISCO': u'https://www.beatport.com/genre/funk-soul-disco/40/',

        u'FUNKY / GROOVE / JACKIN\' HOUSE': u'https://www.beatport.com/genre/funky-groove-jackin-house/81/',

        u'FUTURE HOUSE': u'https://www.beatport.com/genre/future-house/65/',

        u'GARAGE / BASSLINE / GRIME': u'https://www.beatport.com/genre/garage-bassline-grime/86/',

        u'GLITCH HOP': u'https://www.beatport.com/genre/glitch-hop/49/',

        u'HARD DANCE': u'https://www.beatport.com/genre/hard-dance/8/',

        u'HARDCORE / HARD TECHNO': u'https://www.beatport.com/genre/hardcore-hard-techno/2/',

        u'HIP-HOP / R&B': u'https://www.beatport.com/genre/hip-hop-r-and-b/38/',

        u'HOUSE': u'https://www.beatport.com/genre/house/5/',

        u'INDIE DANCE / NU DISCO': u'https://www.beatport.com/genre/indie-dance-nu-disco/37/',

        u'LEFTFIELD BASS': u'https://www.beatport.com/genre/leftfield-bass/85/',

        u'LEFTFIELD HOUSE & TECHNO': u'https://www.beatport.com/genre/leftfield-house-and-techno/80/',

        u'MELODIC HOUSE & TECHNO': u'https://www.beatport.com/genre/melodic-house-and-techno/90/',

        u'MINIMAL / DEEP TECH': u'https://www.beatport.com/genre/minimal-deep-tech/14/',

        u'PROGRESSIVE HOUSE': u'https://www.beatport.com/genre/progressive-house/15/',

        u'PSY-TRANCE': u'https://www.beatport.com/genre/psy-trance/13/',

        u'REGGAE / DANCEHALL / DUB': u'https://www.beatport.com/genre/reggae-dancehall-dub/41/',

        u'TECH HOUSE': u'https://www.beatport.com/genre/tech-house/11/',

        u'TECHNO': u'https://www.beatport.com/genre/techno/6/',

        u'TRANCE': u'https://www.beatport.com/genre/trance/7/',

        u'TRAP / FUTURE BASS': u'https://www.beatport.com/genre/trap-future-bass/87/'

        }





# url страницы, с которой составлять таблицу track

# url = 'https://www.beatport.com/genre/funk-soul-disco/40/top-100'



# создание таблицы track



# file = open('todo.dll', 'r', encoding='utf-8')

# stylename = str(file.readline())[:-1]

# count = int(str(file.readline())[:-1])

# type = str(file.readline())

# file.close()



output_tracks(get_tracks_list(get_url(stylename, type)), count)

