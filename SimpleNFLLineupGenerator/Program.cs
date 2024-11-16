using System.Net;
using System;
using HtmlAgilityPack;
using SimpleNFLLineupGenerator.BOL;
using System.Reflection.Metadata.Ecma335;
using SimpleNFLLineupGenerator.Utilities;

// Get events.
List<NFLEvent> events = CSVTools.GetEvents();

// Get players.
List<NFLObject> projections = CSVTools.GetPlayers();

// Get NumberFire projections.
projections = NumberFire.GetProjections(projections);

// Update projections to have only one position.
projections = DataCleanup.FixPositions(projections);

// Build lineups.
var lineups = DFSLineups.BuildLineups(projections);

// Write lineups csv.
CSVTools.BuildLineupCSV(lineups, events);